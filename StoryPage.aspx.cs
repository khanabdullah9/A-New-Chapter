using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class StoryPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public string _authorName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide the navabar and the footer.
            Control myNavbarCont = this.Page.Master.FindControl("navbar1");
            Control myFooterCont = this.Page.Master.FindControl("footer1");
            if (myNavbarCont != null)
            {
                myNavbarCont.Visible = false;
            }
            if (myFooterCont != null)
            {
                myFooterCont.Visible = false;
            }
            //Requests the query string coming from bookshelf page
            string _bookID = Request.QueryString["bookid"];
            //dynamically adds the markup and prints the content on the page
            HtmlTags(SQLQuery(_bookID));
        }
        //Sql query method to retrieve the corresponding book file from database
        protected string SQLQuery(string id)
        {
            byte[] _bookFile = new byte[1000];
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select book_file,author_name from master_book_table where book_id='" + id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        _bookFile = dr.GetSqlBytes(0).Value;//returns the sql byte array
                        _authorName = dr.GetString(1);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            //converts the UTF-8 byte[] to string format
            return  System.Text.Encoding.UTF8.GetString (_bookFile);
        }
        //Markup method
        protected void HtmlTags(string t) 
        {

            Response.Write("<div class='row'>");
            Response.Write("<div class='col-md-6 mr-auto' style='margin-top:-80px;'>");
            Response.Write("<div class='paper'>");
            Response.Write("<div class='holes'></div>");
            Response.Write("<textarea runat = 'server' id='ta1'>" + t + "</textarea>");
            Response.Write("</div>");
            Response.Write("</div>");
            Response.Write("</div>");
        }
    }
}
