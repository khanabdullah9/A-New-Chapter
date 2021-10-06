using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class BookInventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try 
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    string _imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["book_image"]);
                    (e.Row.FindControl("Image2") as Image).ImageUrl = _imageUrl;
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
                Response.Redirect("~/Errors.aspx");
            }
        }
        //Download file button
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text != string.Empty)
                {
                    byte[] _bytes;
                    string _fileName, _contentType;
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select * from master_book_table where book_id='" + TextBox1.Text.Trim() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    _fileName = dr["book_name"].ToString();
                    _bytes = dr["book_file"] as byte[];
                    _contentType = dr["file_contentType"].ToString();
                    con.Close();
                    Response.Clear();//Clears the response object
                    Response.Buffer = true;//waits untill the output is generated
                    Response.Charset = "";//sets the charset
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);//disables caching
                    Response.ContentType = _contentType;//content type 
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + _fileName + SetFileExtention(_contentType));//sets the file name
                    Response.BinaryWrite(_bytes);//writes the byte array to the output
                    Response.Flush();//sends the output
                    Response.End();//closes the process
                    dr.Close();
                }
                else
                {
                    Response.Write("<script>alert('Enter book ID');</script>");
                }
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

        private string SetFileExtention(string ct)
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

        //Delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            try 
            {
                if (TextBox1.Text != string.Empty)
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }                    
                    SqlCommand cmd1 = new SqlCommand("delete from master_book_table where book_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book has been deleted');</script>");
                }
                else 
                {
                    Response.Write("<script>alert('Enter book ID');</script>");
                }
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
        //Go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text != string.Empty)
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select * from master_book_table where book_id='" + TextBox1.Text.Trim() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {                            
                            Label5.Text = dr.GetString(1);
                            Label6.Text = dr.GetString(2);
                            Label7.Text = dr["book_price"].ToString();
                            Label8.Text = dr.GetString(3);
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Book does not exist');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Enter book ID');</script>");
                }
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
        //Download book image
        protected void Button4_Click(object sender, EventArgs e)
        {
            try 
            {
                if (TextBox1.Text != string.Empty)
                {
                    byte[] _bytes;
                    string _fileName, _contentType;
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select * from master_book_table where book_id='" + TextBox1.Text.Trim() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    _fileName = dr["book_name"].ToString();
                    _bytes = dr["book_image"] as byte[];
                    _contentType = dr["img_contentType"].ToString();
                    con.Close();
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = _contentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + _fileName + SetImageExtention(_contentType));
                    Response.BinaryWrite(_bytes);
                    Response.Flush();
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('Enter book ID');</script>");
                }
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

        private string SetImageExtention(string ct)
        {
            string ext = "";
            if (ct.Equals("image/jpeg"))
            {
                ext = ".jpg";
            }
            else if (ct.Equals("image/png"))
            {
                ext = ".png";
            }
            else if (ct.Equals("image/bmp")) 
            {
                ext = ".bmp";
            }
            return ext;
        }
        //Send for review
        protected void Button5_Click(object sender, EventArgs e)
        {
            try 
            {
                if (TextBox1.Text != string.Empty)
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand("update master_book_table set approved=0 where book_id='" + TextBox1.Text.Trim() + "'", con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Response.Write("<script>alert('Book has been sent for review');</script>");
                }
                else 
                {
                    Response.Write("<script>alert('Enter book ID');</script>");
                }
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
    }
}