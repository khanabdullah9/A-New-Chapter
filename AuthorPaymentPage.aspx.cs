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
    public partial class AuthorPaymentPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                BindData();//Binds the gridview irrespective of the postback
            }
        }
        protected void BindData() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from master_book_table inner join sold_book_record on master_book_table.book_id=sold_book_record.book_id inner join master_author_table on master_author_table.author_name=master_book_table.author_name and paid=0;", con);
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try 
            {
                int _dbID = 0;
                if (e.CommandName.Equals("Paid"))
                {
                    _dbID = Convert.ToInt32(e.CommandArgument);
                }
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("update sold_book_record set paid=1 where ID='" + _dbID + "'", con);
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