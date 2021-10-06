using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class AdminMemberManagementPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
        }
        //Go button
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
                    SqlCommand cmd = new SqlCommand("select * from master_user_table where user_name='" + TextBox1.Text.Trim() + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TextBox2.Text = dr["status"].ToString();
                            Label1.Text = dr["email"].ToString();
                            Label2.Text = dr["phone"].ToString();
                            Label3.Text = dr["city"].ToString();
                            Label4.Text = dr["full_name"].ToString();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Member does not exist');</script>");
                    }
                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('Enter user_name');</script>");
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
                SqlCommand cmd = new SqlCommand("update master_user_table set status='active' where user_name='"+TextBox1.Text.Trim()+"'", con);
                cmd.ExecuteNonQuery();
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
        //pause button
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update master_user_table set status='pause' where user_name='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
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
        // Block user // Cannot delete member beacuse it is conflicting with the foreign key constraints of the other tables
        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update master_user_table set status='block' where user_name='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Member has been blocked');</script>");
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
    }
}