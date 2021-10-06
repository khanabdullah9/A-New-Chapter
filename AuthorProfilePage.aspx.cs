using A_New_Chapter.DAL;
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
    public partial class AuthorProfilePage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string _authorName = Request.QueryString["authorname"];//query string coming from bookstore page 'view' button
            if (_authorName!=null) //if the user/author has clicked on the view btn on the bookstore page
            {
                TextBox1.Text =_authorName;
            }
            TextBox1.Focus();
            Image1.Visible = false;
            Label10.Visible = false;
            if (Session["role"]==null) 
            {
                Label10.Visible = true;
                Label10.Text = "You must be logged in to add a like";
                LinkButton1.Visible = false;
            }
            if (Session["role"]!=null) 
            {
                if (Session["role"].Equals("admin"))
                {
                    Label10.Visible = true;
                    Label10.Text = "Admin cannot like";
                    LinkButton1.Visible = false;
                }
            }
            
            
        }
        //go button
        protected void populateServerControls() 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from master_author_table where author_name='" + TextBox1.Text.Trim() + "'", con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Image1.Visible = true;
                                    byte[] imageData = (byte[])dr["image"];
                                    string img = Convert.ToBase64String(imageData, 0, imageData.Length);//convert byte array to base 64 string
                                    Image1.ImageUrl = "data:image/png;base64," + img;//setting the image url

                                    Label5.Text = dr["full_name"].ToString();
                                    Label6.Text = dr["reputation_points"].ToString();
                                    Label7.Text = dr["email"].ToString();
                                    Label8.Text = dr["bio"].ToString();
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Author does not exist');</script>");
                                Image1.Visible = false;
                            }
                            dr.Close();
                        }
                    }
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != string.Empty)
            {
                populateServerControls();
            }
            else 
            {
                Response.Write("<script>alert('Enter author_name');</script>");
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e) 
        {
            try 
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["book_image"]);
                    (e.Row.FindControl("Image2") as Image).ImageUrl = imageUrl;
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
        //add like button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try 
            {
                Image1.Visible = true;
                if (TextBox1.Text != string.Empty)
                {
                    if (Session["role"].Equals("user"))
                    {
                        using (SqlConnection con1 = new SqlConnection(strcon))
                        {
                            con1.Open();
                            using (SqlCommand cmd1 = new SqlCommand("select * from likes_record where liker='" + Session["user_name"] + "' and author_name='" + TextBox1.Text.Trim() + "' and role='" + Session["role"] + "'", con1))
                            {
                                using (SqlDataAdapter da1 = new SqlDataAdapter(cmd1))
                                {
                                    using (DataTable dt1 = new DataTable())
                                    {
                                        da1.Fill(dt1);
                                        if (dt1.Rows.Count >= 1)//user already liked the author
                                        {
                                            Label10.Text = "You have already liked '" + TextBox1.Text.Trim() + "'";
                                            Label10.Visible = true;
                                        }
                                        else
                                        {
                                            using (SqlCommand cmd2 = new SqlCommand("update master_author_table set reputation_points+=1 where author_name='" + TextBox1.Text.Trim() + "'", con1))
                                            {
                                                cmd2.ExecuteNonQuery();
                                            }
                                            using (SqlCommand cmd3 = new SqlCommand("insert into likes_record (liker,author_name,role) values ('" + Session["user_name"] + "','" + TextBox1.Text.Trim() + "','" + Session["role"] + "')", con1))
                                            {
                                                cmd3.ExecuteNonQuery();
                                            }
                                            Label10.Text = "Your like has been added";
                                            Label10.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (Session["role"].Equals("author"))
                    {
                        using (SqlConnection con2 = new SqlConnection(strcon))
                        {
                            con2.Open();
                            using (SqlCommand cmd4 = new SqlCommand("select * from likes_record where liker='" + Session["author_name"] + "' and author_name='" + TextBox1.Text.Trim() + "' and role='" + Session["role"] + "'", con2))
                            {
                                using (SqlDataAdapter da2 = new SqlDataAdapter(cmd4))
                                {
                                    using (DataTable dt2 = new DataTable())
                                    {
                                        da2.Fill(dt2);
                                        if (dt2.Rows.Count >= 1)//author already liked the author
                                        {
                                            Label10.Text = "You have already liked '" + TextBox1.Text.Trim() + "'";
                                            Label10.Visible = true;
                                        }
                                        else
                                        {
                                            using (SqlCommand cmd5 = new SqlCommand("update master_author_table set reputation_points+=1 where author_name='" + TextBox1.Text.Trim() + "'", con2))
                                            {
                                                cmd5.ExecuteNonQuery();
                                            }
                                            using (SqlCommand cmd6 = new SqlCommand("insert into likes_record (liker,author_name,role) values ('" + Session["author_name"] + "','" + TextBox1.Text.Trim() + "','" + Session["role"] + "')", con2))
                                            {
                                                cmd6.ExecuteNonQuery();
                                            }
                                            Label10.Text = "Your like has been added";
                                            Label10.Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (Session["role"].Equals(""))
                    {
                        Label10.Text = "You must be logged in to add a like";
                        Label10.Visible = true;
                    }
                }
                else 
                {
                    Image1.Visible = false;
                    Response.Write("<script>alert('Enter author_name');</script>");
                }
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            try 
            {
                GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
                Label _comment = (Label)row.FindControl("Label11");
               
                
            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
    }
}