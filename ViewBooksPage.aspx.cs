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
    public partial class ViewBooksPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string _bookID = "";
        string _userName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"]!=null) 
            {
                if (Session["role"].Equals("author"))
                {
                    _userName = Session["author_name"].ToString();
                }
                else if (Session["role"].Equals("user"))
                {
                    _userName = Session["user_name"].ToString();
                }
                else if (Session["role"].Equals("admin")) 
                {
                    Button2.Enabled = false;
                    Button2.ToolTip = "Admin can not post a review";
                }
            }            
            else if (Session["role"]==null) 
            {
                _userName = null;
                Button2.Enabled = false;
                Button2.ToolTip = "Login to post a review";
            }
            _bookID = Request.QueryString["bookID"];
            PopulateServerControls();
        }
        byte[] _bookImage = new byte[1000];
        string img;
        protected void PopulateServerControls() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from master_book_table where book_id='" + _bookID + "'", con);
                SqlDataReader dreader = cmd.ExecuteReader();
                if (dreader.HasRows)
                {
                    while (dreader.Read())
                    {
                        Label1.Text = dreader.GetString(1);
                        Label2.Text = dreader.GetString(2);
                        Label3.Text = dreader["book_price"].ToString();
                        Label4.Text = dreader.GetString(7);
                        Label5.Text = dreader.GetString(3);
                        _bookImage = (byte[])dreader["book_image"];
                        img = Convert.ToBase64String(_bookImage, 0, _bookImage.Length);
                        Image1.ImageUrl = "data:image/jpg;base64," + img;
                    }
                }
                dreader.Close();
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
        //Post button
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string _commenterRole = "";
                if (Session["role"].Equals("author"))
                {
                    _commenterRole = "author";
                }
                else if (Session["role"].Equals("user"))
                {
                    _commenterRole = "user";
                }
                Random _random = new Random();
                int _ranNum = _random.Next(100, 999);
                int _len = 3;
                string _ranStr = "";
                for (int i = 1; i <= _len; i++)
                {
                    _ranStr = ((char)(_random.Next(1, 26) + 64)).ToString().ToLower();
                }
                string _commentID = "br_" + _ranStr + _ranNum;
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                DateTime now = DateTime.Now;
                SqlCommand cmd = new SqlCommand("insert into review_box (comment_id,comment_from,comment_text,book_id,commenter_role,comment_time) values ('" + _commentID + "','" + _userName + "','" + TextBox1.Text.Trim() + "','" + _bookID + "','" + _commenterRole + "',GetDate())", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect(Request.Url.AbsoluteUri);
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