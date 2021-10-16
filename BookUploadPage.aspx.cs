using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class BookUploadPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            LoggedIn();
            SetPrice();
            
        }
        //Sets price according to the points
        protected void SetPrice() 
        {
            try
            {
                int _points = 0;
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from master_author_table where author_name='" + TextBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _points = dr.GetInt32(12);
                    }
                }
                if (_points >= 0 && _points <= 500)
                {
                    RangeValidator1.MaximumValue = "0";
                    RangeValidator1.MinimumValue = "0";
                }
                else if (_points >= 501 && _points <= 1000)
                {
                    RangeValidator1.MaximumValue = "10";
                    RangeValidator1.MinimumValue = "0";
                }
                else if (_points >= 1001 && _points <= 1500)
                {
                    RangeValidator1.MaximumValue = "25";
                    RangeValidator1.MinimumValue = "0";
                }
                else if (_points >= 1501 && _points <= 10000)
                {
                    RangeValidator1.MaximumValue = "50";
                    RangeValidator1.MinimumValue = "0";
                }
                else if (_points > 10000)
                {
                    RangeValidator1.MaximumValue = "100";
                    RangeValidator1.MinimumValue = "0";
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
        //checks if author is logged in
        protected void LoggedIn() 
        {
            try 
            {
                if (Session["author_name"] != null)
                {
                    TextBox1.Text = Session["author_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Login first');</script>");
                }
            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
        //upload button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {               
                    Random rdm = new Random();
                    int genRdm = rdm.Next(100, 999);
                    string op = "";
                    for (int i = 1; i <= 3; i++)
                    {
                        op += ((char)(rdm.Next(1, 26) + 64)).ToString().ToLower();
                    }
                    string bookIdString = "b" + genRdm + op;

                    //Getting the image file data
                    HttpPostedFile postedFile1 = FileUpload1.PostedFile;//image file
                    string fileName1 = Path.GetFileName(postedFile1.FileName);
                    string fileExtention1 = Path.GetExtension(fileName1);
                    int fileSize1 = postedFile1.ContentLength;
                    string contentType1 = FileUpload1.PostedFile.ContentType;

                    //getting book file data
                    string fileName2 = Path.GetFileName(FileUpload2.PostedFile.FileName);
                    string fileExtention2 = Path.GetExtension(fileName2);
                    int fileSize2 = FileUpload2.PostedFile.ContentLength;
                    string contentType2 = FileUpload2.PostedFile.ContentType;


                    if (FileUpload1.HasFile && FileUpload2.HasFile)
                    {
                        if ((fileExtention1.ToLower() == ".jpg" || fileExtention1.ToLower() == ".png" || fileExtention1.ToLower() == ".bmp" || fileExtention1.ToLower() == ".jpeg") &&
                            (fileExtention2.ToLower() == ".txt")
                            && (fileSize1<= 2097152 && fileSize2<= 2097152))//max 2mb
                        {
                            //converting to binary stream
                            Stream stream1 = postedFile1.InputStream;
                            BinaryReader binaryReader1 = new BinaryReader(stream1);
                            byte[] bytes1 = binaryReader1.ReadBytes((int)stream1.Length);

                            //converting to file stream
                            string contentType = FileUpload2.PostedFile.ContentType;
                            Stream fileStream = FileUpload2.PostedFile.InputStream;
                            BinaryReader binaryReader2 = new BinaryReader(fileStream);
                            byte[] bytes2 = binaryReader2.ReadBytes((Int32)fileStream.Length);

                            using (SqlConnection con = new SqlConnection(strcon))
                            {
                                con.Open();
                                SqlCommand cmd = new SqlCommand("insert into master_book_table (book_id,book_name,book_genre,book_description,book_image,book_file,book_price,author_name,file_contentType,img_contentType,approved) values (@book_id,@book_name,@book_genre,@book_description,@book_image,@book_file,@book_price,@author_name,@file_contentType,@img_contentType,@approved)", con);
                                cmd.Parameters.AddWithValue("@book_id", bookIdString);
                                cmd.Parameters.AddWithValue("@book_name", TextBox5.Text.Trim());
                                cmd.Parameters.AddWithValue("@book_genre", TextBox2.Text.Trim());
                                cmd.Parameters.AddWithValue("@book_description", TextBox4.Text.Trim());
                                cmd.Parameters.AddWithValue("@book_image", bytes1);
                                cmd.Parameters.AddWithValue("@book_file", bytes2);
                                cmd.Parameters.AddWithValue("@book_price", TextBox3.Text.Trim());
                                cmd.Parameters.AddWithValue("@author_name", TextBox1.Text.Trim());
                                cmd.Parameters.AddWithValue("@file_contentType",contentType2);
                                cmd.Parameters.AddWithValue("@img_contentType",contentType1);
                                cmd.Parameters.AddWithValue("@approved",0);
                                cmd.ExecuteNonQuery();
                                Label1.Visible = true;
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Invalid file type (hover over the respective file upload buttons to see the required file type)');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Upload required files');</script>");
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