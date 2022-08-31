using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class UserSignUpPage : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //sets cursor on the textbox
            TextBox1.Focus();
        }
        //User sign up button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (isUserPresent())
            {
                Response.Write("<script>alert('User name is already taken')</script>");
            }
            else 
            {
                SignUpUser();
            }
        }
        protected void SignUpUser() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into master_user_table (full_name,email,phone,city,pincode,state,full_address,user_name,password,status,country) values " +
                    "(@full_name,@email,@phone,@city,@pincode,@state,@full_address,@user_name,@password,@status,@country)", con);
                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@user_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", EncryptString(TextBox3.Text.Trim()));//Password is encrypted
                cmd.Parameters.AddWithValue("@status", "pending");
                cmd.Parameters.AddWithValue("@country", DropDownList2.SelectedValue.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successful')</script>");
            }
            catch (ThreadAbortException tbe) 
            {
                Server.ClearError();
            }
            catch (Exception ex)
            {
                //Logger.Log(ex, EventLogEntryType.Warning);
                //Server.ClearError();
                //Server.Transfer("~/Errors.aspx");
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
}
        protected bool isUserPresent() 
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from master_user_table where user_name='" + TextBox2.Text.Trim() + "'", con);
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
                Logger.Log(ex, EventLogEntryType.Warning);
                Server.ClearError();
                Server.Transfer("~/Errors.aspx");
                Response.Write("<script>alert('" + ex.Message + "')</script>");
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
    }
}