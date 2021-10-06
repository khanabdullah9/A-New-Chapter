using System;   
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class AuthorRegisterPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Register button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (isAuthorPresent())
            {
                Response.Write("<script>alert('Author name is already taken');</script>");
            }
            else
            {
                RegisterAuthor();
            }
        }
        protected void RegisterAuthor() 
        {
            try
            {
                HttpPostedFile postedFile = FileUpload1.PostedFile;//Accesses the file uploaded
                string filename = Path.GetFileName(postedFile.FileName);//Gets the file name from the file

                string fileExtension = Path.GetExtension(filename);//gets the file extention from the file
                int fileSize = postedFile.ContentLength;//file size
                if (FileUpload1.HasFile)
                {
                    if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                        using (SqlConnection con = new SqlConnection(strcon))
                        {
                            SqlCommand cmd = new SqlCommand("spAuthorRegister", con);
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;

                            SqlParameter full_name = new SqlParameter()
                            {
                                ParameterName = "@full_name",
                                Value = TextBox3.Text.Trim()
                            };
                            cmd.Parameters.Add(full_name);

                            SqlParameter email = new SqlParameter()
                            {
                                ParameterName = "@email",
                                Value = TextBox4.Text.Trim()
                            };
                            cmd.Parameters.Add(email);

                            SqlParameter phone = new SqlParameter()
                            {
                                ParameterName = "@phone",
                                Value = TextBox5.Text.Trim()
                            };
                            cmd.Parameters.Add(phone);

                            SqlParameter city = new SqlParameter()
                            {
                                ParameterName = "@city",
                                Value = TextBox6.Text.Trim()
                            };
                            cmd.Parameters.Add(city);

                            SqlParameter pincode = new SqlParameter()
                            {
                                ParameterName = "@pincode",
                                Value = TextBox7.Text.Trim()
                            };
                            cmd.Parameters.Add(pincode);

                            SqlParameter state = new SqlParameter()
                            {
                                ParameterName = "@state",
                                Value = DropDownList1.Text.Trim()
                            };
                            cmd.Parameters.Add(state);

                            SqlParameter full_address = new SqlParameter()
                            {
                                ParameterName = "@full_address",
                                Value = TextBox8.Text.Trim()
                            };
                            cmd.Parameters.Add(full_address);

                            SqlParameter bio = new SqlParameter()
                            {
                                ParameterName = "@bio",
                                Value = TextBox9.Text.Trim()
                            };
                            cmd.Parameters.Add(bio);

                            SqlParameter author_name = new SqlParameter()
                            {
                                ParameterName = "@author_name",
                                Value = TextBox1.Text.Trim()
                            };
                            cmd.Parameters.Add(author_name);

                            SqlParameter password = new SqlParameter()
                            {
                                ParameterName = "@password",
                                Value = EncryptString(TextBox2.Text.Trim())
                            };
                            cmd.Parameters.Add(password);

                            SqlParameter status = new SqlParameter()
                            {
                                ParameterName = "@status",
                                Value = "pending"
                            };
                            cmd.Parameters.Add(status);

                            SqlParameter image = new SqlParameter()
                            {
                                ParameterName = "@image",
                                Value = bytes
                            };
                            cmd.Parameters.Add(image);

                            SqlParameter NewId = new SqlParameter()
                            {
                                ParameterName = "@NewId",
                                Value = -1,
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(NewId);

                            SqlParameter reputation_points = new SqlParameter()
                            {
                                ParameterName = "@reputation_points",
                                Value = 0
                            };
                            cmd.Parameters.Add(reputation_points);
                            SqlParameter country = new SqlParameter()
                            {
                                ParameterName = "@country",
                                Value = DropDownList2.SelectedValue
                            };
                            cmd.Parameters.Add(country);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            Response.Write("<script>alert('Registered Successfully');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Only images (.jpg, .png, .gif and .bmp) can be uploaded');</script>");
                    }
                }
                else 
                {
                    Response.Write("<script>alert('Upload an image');</script>");
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
        protected bool isAuthorPresent() 
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from master_author_table where author_name='" + TextBox1.Text.Trim() + "' and password='" + EncryptString(TextBox2.Text.Trim()) + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    return true;
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
            return false;
        }
        public string EncryptString(string str) 
        {
            using (SHA256 sHA256 = SHA256.Create()) 
            {
                byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder stringBuilder = new StringBuilder();
                for (int i=0;i<bytes.Length;i++) 
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuthorLoginPage.aspx");
        }
    }
}
  