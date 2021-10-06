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
    public partial class AdminLoginPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
        }
        //Admin Login Page
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from master_admin_table where admin_name='" + TextBox1.Text.Trim() + "' and password='" + EncryptString(TextBox2.Text.Trim()) + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["admin_name"] = dr.GetValue(0).ToString();
                        Session["role"] = "admin";
                    }
                    Response.Redirect("~/homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid login credentials')</script>");
                }
            }
            catch (ThreadAbortException tbe) 
            {
                Server.ClearError();
            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('" + ex.Message + "')</script>");
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        protected string EncryptString(string str) 
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
    }
}