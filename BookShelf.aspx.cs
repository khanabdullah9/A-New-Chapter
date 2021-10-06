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
    public partial class BookShelf : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                GridViewBinder1();
            }
            Control myFooter = this.Page.Master.FindControl("footer1");
            myFooter.Visible = false;
        }
        protected void GridViewBinder1()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from master_book_table inner join sold_book_record on master_book_table.book_id=sold_book_record.book_id and sold_book_record.user_name='" + Session["user_name"] + "' and sold_book_record.isShelved=1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
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


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView dr = (DataRowView)e.Row.DataItem;
                    string _imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["book_image"]);
                    (e.Row.FindControl("MyImage") as Image).ImageUrl = _imageUrl;
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
        public string _bookID = "";
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Read")) 
                {
                    _bookID = e.CommandArgument.ToString();
                    Response.Redirect("~/StoryPage.aspx?bookid="+_bookID);
                }
                if (e.CommandName.Equals("Remove")) 
                {
                    _bookID = e.CommandArgument.ToString();
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State==ConnectionState.Closed) 
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("update sold_book_record set isShelved=0 where book_id='"+_bookID+"' and user_name='"+Session["user_name"]+"'",con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);
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
    }
}