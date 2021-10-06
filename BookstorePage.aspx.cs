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
    public partial class BookstorePage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label6.Visible = false;
            Label7.Visible = false;
            if (Session["role"] == null)
            {
                //Response.Write("<script>alert('Login first');</script>");
            }
            if (Session["user_name"] !=null) 
            {
                Label6.Text = Session["user_name"].ToString();
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
                    (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
                    if (Session["role"] != null)
                    {
                        if (Session["role"].Equals("author") || Session["role"].Equals("admin"))//only user can buy the book
                        {
                            (e.Row.FindControl("Button1") as Button).Enabled = false;
                            (e.Row.FindControl("Button1") as Button).ToolTip = "Login as user";
                        }
                    }
                    else
                    {
                        (e.Row.FindControl("Button1") as Button).Enabled = false;
                        (e.Row.FindControl("Button1") as Button).ToolTip = "Login as user";
                    }
                }
            }
            catch (ThreadAbortException tbe) 
            {
                Server.ClearError();
            }
            catch (Exception ex) 
            {
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string _bookId = "";
                double _bookPrice = 0;
                string _bookName = "";
                byte[] _bookImage = new byte[1000];
                string _bookDescription = "";
                SqlConnection con = new SqlConnection(strcon);
                if (e.CommandName.Equals("Add"))
                {
                    _bookId = e.CommandArgument.ToString();
                    Session["bookID"] = _bookId;
                    Button btn = e.CommandSource as Button;
                    btn.Text = "Added";
                    btn.Enabled = false;
                }
                if (e.CommandName.Equals("Profile"))
                {
                    string _AuthorName = e.CommandArgument.ToString();
                    Response.Redirect("~/AuthorProfilePage.aspx?authorname=" + _AuthorName);
                }
                if (e.CommandName.Equals("View"))
                {
                    string ID = e.CommandArgument.ToString();
                    Response.Redirect("~/ViewBooksPage.aspx?bookID=" + ID);
                }
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd1 = new SqlCommand("select * from master_book_table where book_id='" + _bookId + "'", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _bookPrice = Convert.ToDouble(dr["book_price"]);
                        _bookName = dr.GetString(1);
                        _bookImage = dr.GetSqlBytes(4).Value;
                        _bookDescription = dr.GetString(3);
                        //Response.Write("<script>alert('" + _bookImage + "');</script>");
                    }
                }
                dr.Close();
                dr.Dispose();

                InsertInto_sold_book_record(_bookId, _bookName, _bookPrice, _bookImage, _bookDescription, 0);
                InsertIntoCheckout(_bookId, _bookName, _bookPrice);

                Response.Redirect("~/PayPalCheckoutPage.aspx?bookName="+_bookName);
                con.Close();
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        protected void OnRowDataBound2(object sender, GridViewRowEventArgs e) 
        {
            try 
            {
                if (e.Row.RowType==DataControlRowType.DataRow) 
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    string _imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["book_image"]);
                    (e.Row.FindControl("Image2") as Image).ImageUrl = _imageUrl;
                    if (Session["role"] != null)
                    {
                        if (Session["role"].Equals("author") || Session["role"].Equals("admin"))
                        {
                            (e.Row.FindControl("Button3") as Button).Enabled = false;
                            (e.Row.FindControl("Button3") as Button).ToolTip = "Login as user";
                        }
                    }
                    else 
                    {
                        (e.Row.FindControl("Button3") as Button).Enabled = false;
                        (e.Row.FindControl("Button3") as Button).ToolTip = "Login as user";
                    }
                }
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            try
            {
                string _bookID = "";
                double _bookPrice = 0;
                string _bookName = "";
                byte[] _bookImage = new byte[1000];
                string _bookDescription = "";
                if (e.CommandName.Equals("Add")) 
                {
                    _bookID = e.CommandArgument.ToString();
                    Session["book_id"] = _bookID;
                    Button btn = e.CommandSource as Button;
                    btn.Text = "Added";
                    btn.Enabled = false;
                }
                if (e.CommandName.Equals("Profile")) 
                {
                    string _authorName = e.CommandArgument.ToString();
                    Response.Redirect("~/AuthorProfilePage.aspx?authorname="+_authorName);
                }
                if (e.CommandName.Equals("View"))
                {
                    string ID = e.CommandArgument.ToString();
                    Response.Redirect("~/ViewBooksPage.aspx?bookID=" + ID);
                }
                SqlConnection con = new SqlConnection(strcon);
                if (con.State==ConnectionState.Closed) 
                {
                    con.Open();
                }
                SqlCommand cmd1 = new SqlCommand("select * from master_book_table where book_id='"+_bookID+"'",con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows) 
                {
                    while (dr.Read()) 
                    {
                        _bookPrice = Convert.ToDouble(dr["book_price"]);
                        _bookName = dr.GetString(1);
                        _bookImage = dr.GetSqlBytes(4).Value;
                        _bookDescription = dr.GetString(3);
                    }
                }
                dr.Close();
                dr.Dispose();

                InsertInto_sold_book_record(_bookID, _bookName, _bookPrice, _bookImage, _bookDescription, 0);
                InsertIntoCheckout(_bookID, _bookName, _bookPrice);

                Response.Redirect("~/PayPalCheckoutPage.aspx?bookName="+_bookName);
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void OnRowDataBound3(object sender, GridViewRowEventArgs e) 
        {
            try 
            {
                if (e.Row.RowType==DataControlRowType.DataRow) 
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    string _imageUrl = "data:image/jpg;base64," +Convert.ToBase64String((byte[])dr["book_image"]);
                    (e.Row.FindControl("Image3") as Image).ImageUrl = _imageUrl;
                    if (Session["role"] != null)
                    {
                        if (Session["role"].Equals("author") || Session["role"].Equals("admin"))
                        {
                            (e.Row.FindControl("Button5") as Button).Enabled = false;
                            (e.Row.FindControl("Button5") as Button).ToolTip = "Login as user";
                        }
                    }
                    else 
                    {
                        (e.Row.FindControl("Button5") as Button).Enabled = false;
                        (e.Row.FindControl("Button5") as Button).ToolTip = "Login as user";
                    }
                }
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            try
            {
                string _bookID = "";
                double _bookPrice = 0;
                string _bookName = "";
                byte[] _bookImage = new byte[1000];
                string _bookDescription = "";
                if (e.CommandName.Equals("Add"))
                {
                    _bookID = e.CommandArgument.ToString();
                    Session["book_id"] = _bookID;
                    Button btn = e.CommandSource as Button;
                    btn.Text = "Added";
                    btn.Enabled = false;
                }
                if (e.CommandName.Equals("Profile"))
                {
                    string _authorName = e.CommandArgument.ToString();
                    Response.Redirect("~/AuthorProfilePage.aspx?authorname=" + _authorName);
                }
                if (e.CommandName.Equals("View"))
                {
                    string ID = e.CommandArgument.ToString();
                    Response.Redirect("~/ViewBooksPage.aspx?bookID=" + ID);
                }
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd1 = new SqlCommand("select * from master_book_table where book_id='" + _bookID + "'", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows) 
                {
                    while (dr.Read()) 
                    {
                        _bookPrice = Convert.ToDouble(dr["book_price"]);
                        _bookName = dr.GetString(1);
                        _bookImage = dr.GetSqlBytes(4).Value;
                        _bookDescription = dr.GetString(3);
                    }
                }
                dr.Close();
                dr.Dispose();

                InsertInto_sold_book_record(_bookID,_bookName,_bookPrice,_bookImage,_bookDescription,0);                
                InsertIntoCheckout(_bookID,_bookName,_bookPrice);

                Response.Redirect("~/PayPalCheckoutPage.aspx?bookName=" + _bookName);
                con.Close();
            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
        protected void OnRowDataBound4(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    string _imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["book_image"]);
                    (e.Row.FindControl("Image4") as Image).ImageUrl = _imageUrl;
                    if (Session["role"] != null)
                    {
                        if (Session["role"].Equals("author") || Session["role"].Equals("admin"))
                        {
                            (e.Row.FindControl("Button7") as Button).Enabled = false;
                            (e.Row.FindControl("Button7") as Button).ToolTip = "Login as user";
                        }
                    }
                    else 
                    {
                        (e.Row.FindControl("Button7") as Button).Enabled = false;
                        (e.Row.FindControl("Button7") as Button).ToolTip = "Login as user";
                    }
                }
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string _bookID = "";
                double _bookPrice = 0;
                string _bookName = "";
                byte[] _bookImage = new byte[1000];
                string _bookDescription = "";
                if (e.CommandName.Equals("Add"))
                {
                    _bookID = e.CommandArgument.ToString();
                    Session["book_id"] = _bookID;
                    Button btn = e.CommandSource as Button;
                    btn.Text = "Added";
                    btn.Enabled = false;
                }
                if (e.CommandName.Equals("Profile"))
                {
                    string _authorName = e.CommandArgument.ToString();
                    Response.Redirect("~/AuthorProfilePage.aspx?authorname=" + _authorName);
                }
                if (e.CommandName.Equals("View"))
                {
                    string ID = e.CommandArgument.ToString();
                    Response.Redirect("~/ViewBooksPage.aspx?bookID=" + ID);
                }
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd1 = new SqlCommand("select * from master_book_table where book_id='" + _bookID + "'", con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _bookPrice = Convert.ToDouble(dr["book_price"]);
                        _bookName = dr.GetString(1);
                        _bookImage = dr.GetSqlBytes(4).Value;
                        _bookDescription = dr.GetString(3);
                    }
                }
                dr.Close();
                dr.Dispose();

                InsertInto_sold_book_record(_bookID,_bookName,_bookPrice,_bookImage,_bookDescription,1);
                con.Close();
                Response.Write("<script>alert('Your book has been placed on the book shelf');</script>");
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        protected void InsertInto_sold_book_record(string _bookId,string _bookName,double _bookPrice,byte[] _bookImage,string _bookDescription,int _isShelved) 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd2 = new SqlCommand("insert into sold_book_record(book_id, book_name, book_price, user_name,  book_image, book_description,paid,isShelved) values(@book_id, @book_name, @book_price, @user_name, @book_image, @book_description,@paid,@isShelved)", con);
                cmd2.Parameters.AddWithValue("@book_id", _bookId);
                cmd2.Parameters.AddWithValue("@book_name", _bookName);
                cmd2.Parameters.AddWithValue("@book_price", _bookPrice);
                cmd2.Parameters.AddWithValue("@user_name", Session["user_name"]);
                cmd2.Parameters.AddWithValue("@book_image", _bookImage);
                cmd2.Parameters.AddWithValue("@book_description", _bookDescription);
                cmd2.Parameters.AddWithValue("@paid", 0);
                cmd2.Parameters.AddWithValue("@isShelved", _isShelved);//this will directly shelve the book
                cmd2.ExecuteNonQuery();
            }
            catch (ThreadAbortException tbe) 
            {
                Server.ClearError();
            }
            catch (Exception ex) 
            {
                Logger.Log(ex);
                Server.ClearError();
                Response.Redirect("~/Errors.aspx");
            }
        }
        protected void InsertIntoCheckout(string _bookID,string _bookName,double _bookPrice) 
        {
            try 
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State==ConnectionState.Closed) 
                {
                    con.Open();
                }
                SqlCommand cmd3 = new SqlCommand("insert into checkout (book_id,book_name,book_price,user_name) values ('" + _bookID + "','" + _bookName + "','" + _bookPrice + "','" + Session["user_name"] + "')", con);
                cmd3.ExecuteNonQuery();
                con.Close();
            }
            catch (ThreadAbortException tbe)
            {
                Server.ClearError();
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