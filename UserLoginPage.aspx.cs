using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    public partial class UserLoginPage : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
        }
        //Login Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text != string.Empty || TextBox2.Text != string.Empty)
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string encryptedpswd = EncryptString(TextBox2.Text);//Encrypts the text in the textbox and checks it in the database
                    SqlCommand cmd = new SqlCommand("select * from master_user_table where user_name='" + TextBox1.Text.Trim() + "' and password='" + encryptedpswd + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        string _password = dr["password"].ToString();
                        string _status = dr.GetString(9);
                        if (_status.Equals("block"))
                        {
                            Response.Write("<script>alert('You have been blocked');</script>");
                        }
                        else
                        {
                            Session["user_name"] = dr.GetValue(7).ToString();
                            Session["fullname"] = dr.GetValue(0).ToString();
                            Session["status"] = dr.GetValue(9).ToString();
                            Session["role"] = "user";
                            Response.Redirect("~/homepage.aspx");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid login credentialsAccount does not exist');</script>");
                    }
                    con.Close();
                }
                else 
                {
                    Response.Write("<script>alert('Enter credentials');</script>");
                }
            }
            catch (ThreadAbortException tbe) 
            {
                Server.ClearError();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                Logger.Log(ex, System.Diagnostics.EventLogEntryType.Error);
                Server.ClearError();
                Server.Transfer("~/Errors.aspx");
            }
        }
        public string EncryptString(string str) 
        {
            //byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
            //string encrypted = Convert.ToBase64String(b);
            //return encrypted;
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
            Response.Redirect("~/UserSignUpPage.aspx");
        }
    }
}