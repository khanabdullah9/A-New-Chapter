using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class AdminAuthorManagementPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
        }
        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text != string.Empty)
                {
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
                            TextBox2.Text = dr["status"].ToString();
                            Label1.Text = dr["full_name"].ToString();
                            Label6.Text = dr["email"].ToString();
                            Label2.Text = dr["phone"].ToString();
                            Label3.Text = dr["city"].ToString();
                            Label4.Text = dr["reputation_points"].ToString();
                            Label5.Text = dr["bio"].ToString();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Author does not exist');</script>");
                    }
                }
                else 
                {
                    Response.Write("<script>alert('Enter author_name');</script>");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        //Active button
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update master_author_table set status='active' where author_name='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        //Pause button
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update master_author_table set status='pause' where author_name='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        //delete button 
        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update master_author_table set status='block' where author_name='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Author has been blocked');</script>");
                con.Close();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
    }
}