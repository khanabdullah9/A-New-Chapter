using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class AuthorLoginPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
        }
        //Sign up page redirection
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuthorRegisterPage.aspx");
        }
        //author login
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text != string.Empty || TextBox2.Text != string.Empty)
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        string encryptedpswd = EncryptString(TextBox2.Text.Trim());
                        using (SqlCommand cmd = new SqlCommand("select * from master_author_table where author_name='" + TextBox1.Text.Trim() + "' and password='" + encryptedpswd + "'", con))
                        {
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                       string  _status = dr.GetString(10);
                                        if (_status.Equals("block"))
                                        {
                                            Response.Write("<script>alert('You have been blocked');</script>");
                                        }
                                        else
                                        {
                                            Session["full_name"] = dr.GetValue(0).ToString();
                                            Session["author_name"] = dr.GetValue(9).ToString();
                                            Session["role"] = "author";
                                            Response.Redirect("~/homepage.aspx");
                                        }
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Invalid Login Credentials/Account does not exist');</script>");
                                }
                            }
                        }
                    }
                }
                else 
                {
                    Response.Write("<script>alert('Enter credentials');</script>");
                }
            }
            catch (ThreadAbortException tbe) //Eliminates the thread being used
            {
                Server.ClearError();
                Server.Transfer("~/Errors.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                Logger.Log(ex);
                Server.ClearError();
                Server.Transfer("~/Errors.aspx");
            }
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuthorRegisterPage.aspx");
        }
    }
}