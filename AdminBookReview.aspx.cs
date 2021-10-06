using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class AdminBookReview : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    string _imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["book_image"]);//Converting to base 64 string format
                    (e.Row.FindControl("Image1") as Image).ImageUrl = _imageUrl;
                }
            }
            catch (ThreadAbortException tbe) 
            {
                Server.ClearError();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('"+ex.Message+"');</script>");
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            try
            {
                string _bookID = e.CommandArgument.ToString();
                if (e.CommandName.Equals("Download"))
                {
                    Download(_bookID);
                }
                else if (e.CommandName.Equals("Approve"))
                {
                    ApproveBook(_bookID);
                }
                else if (e.CommandName.Equals("Remove"))
                {
                    string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ';' });//This how we particularly pick values from commandargument
                    string _authorName = commandArgs[0];
                    string _bookID2 = commandArgs[1];
                    RemoveBook(_bookID2);
                    string _sendEmail = ConfigurationManager.AppSettings["SendEmail"];
                    if (_sendEmail.ToLower() == "true")
                    {
                        SendEmail(_authorName);
                    }
                    Response.Redirect(Request.Url.AbsoluteUri);//Redirects to the same webpage
                    Response.Write("<script>alert('Book has been removed and mail has been sent');</script>");
                }
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
            }
            catch (Exception ex) 
            {
                Logger.Log(ex);
                Server.ClearError();
                //Response.Redirect("~/Errors.aspx");//Cannot redirect after sending response
            }
        }
        protected void Download(string _paraBookID) 
        {
            try 
            {
                byte[] _bytes;
                string _fileName, _contentType;
                SqlConnection con = new SqlConnection(strcon);
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from master_book_table where book_id='"+_paraBookID+"'",con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                _fileName = dr["book_name"].ToString();
                _bytes = dr["book_file"] as byte[];
                _contentType = dr["file_contentType"].ToString();
                con.Close();
                Response.Clear();//Clears the response object
                Response.Buffer = true;//Waits untill the output is completely generated
                Response.Charset = "";//Chareacter set property
                Response.Cache.SetCacheability(HttpCacheability.NoCache);//disable caching
                Response.ContentType = _contentType;//setting the content type
                Response.AppendHeader("Content-Disposition", "attachment; filename="+_fileName+SetExtention(_contentType));//sets the name of the file
                Response.BinaryWrite(_bytes);//writes the binary data to the output stream
                Response.Flush();//Sends all the output to the client
                HttpContext.Current.Response.End();//Stops the excution
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
            }
            catch (Exception ex) 
            {
                //Response.Write("<script>alert('"+ ex.Message +"');</script>");
                Logger.Log(ex);
                Response.Redirect("~/Errors.aspx");
            }
        }
        protected string SetExtention(string ct) 
        {
            string ext = "";
            if (ct.Equals("application/msword"))
            {
                ext = ".doc";
            }
            else if (ct.Equals("text/plain"))
            {
                ext = ".txt";
            }
            else if (ct.Equals("application/pdf"))
            {
                ext = ".pdf";
            }
            return ext;
        }
        protected void ApproveBook(string _paramBookID) 
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State==ConnectionState.Closed) 
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update master_book_table set approved=1 where book_id='"+_paramBookID+"'",con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book has been approved');</script>");
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
            }
            catch (Exception ex) 
            {
                //Response.Write("<script>alert('"+ex.Message+"');</script>");
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        protected void RemoveBook(string _paramBookID) 
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State==ConnectionState.Closed) 
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("delete from master_book_table where book_id='"+_paramBookID+"'",con);
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("delete from sold_book_record where book_id='"+_paramBookID+"'",con);//if any user has bought the book
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
            }
            catch (Exception ex) 
            {
                //Response.Write("<script>alert('" + ex.Message + "');</script>");
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        protected void SendEmail(string _paramAuthorName) 
        {
            try 
            {
                string _emailAddress = "";
                SqlConnection con = new SqlConnection(strcon);
                if (con.State==ConnectionState.Closed) 
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from master_author_table where author_name='"+_paramAuthorName+"'",con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _emailAddress = dr.GetString(1);//use on production server
                    }
                }
                /*Sending mail section*/
                MailMessage _mailMessage = new MailMessage("anewchapter96@gmail.com", "anewchapter96@gmail.com");//sender and reciever
                _mailMessage.Body = "Explicit/Derogatory language and sexist comments are prohibited";
                _mailMessage.Subject = "Your book has been rejected";

                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", 587);//using the smtp google and 587 is the port number google uses
                _smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "anewchapter96@gmail.com",
                    Password = "i@mtesting9"
                };
                //Google uses ssl so enabling it
                _smtpClient.EnableSsl = true;
                _smtpClient.Send(_mailMessage);
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
            }
            catch (Exception ex) 
            {
                //Response.Write("<script>alert('"+ex.Message+"');</script>");
                Logger.Log(ex);
                Server.ClearError();                
                Response.Redirect("~/Errors.aspx");
            }
        }
        
    }
}