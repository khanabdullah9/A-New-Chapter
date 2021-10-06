using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class PayPalCheckoutPage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string strcon2 = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static double _totalPrice = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
            _totalPrice = 0;
            GenerateOrderID();
            HFUserName.Value = Session["user_name"].ToString();//Using hidden field so that it can passed in the web method
            //HFUserName.Value = "ak1";//Using hidden field so that it can passed in the web method
            HFBookName.Value = Request.QueryString["bookName"];
        }
        protected void BindData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from sold_book_record where user_name='" + Session["user_name"] + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow gvr in ds.Tables[0].Rows)
                {
                    _totalPrice = Convert.ToInt32(gvr["book_price"]);
                }
                GridView1.Columns[2].FooterText = "Total: " + _totalPrice.ToString();
                LabelPrice.Text = "Total: $" + _totalPrice.ToString();
                HiddenField1.Value = _totalPrice.ToString();
                _totalPrice = 0;
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
        protected void GenerateOrderID()
        {
            Random _random = new Random();
            int _rnNum = _random.Next(100, 999);
            int _len = 3;
            string _rnStr = "";
            for (int i = 0; i < _len; i++)
            {
                _rnStr += ((char)(_random.Next(1, 26) + 64)).ToString().ToLower();
            }
            string OrderID = "ord" + _rnNum + _rnStr;
            HFOrderID.Value = OrderID;//Hidden field present on the markup page
        }

        [System.Web.Services.WebMethod]//used to invoke server side method from client side code i.e javascript
        public static void Send_TransactionDetails(string oid, string tid, double p, string un,string bn)//parameters value coming from js since we cannot use non static variables inside a web method
        {           
            try
            {
                SqlConnection con = new SqlConnection(strcon2);
                if (con.State==ConnectionState.Closed) 
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("insert into transaction_details (orderID,transID,amount_paid,user_name,transTime,status) values  ('"+oid+"','"+tid+"','"+p+"','"+un+"',GetDate(),'COMPLETED')", con);
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("delete from checkout where user_name='"+un+"'",con);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand("update sold_book_record set isShelved=1 where user_name='"+un+"'",con);
                cmd3.ExecuteNonQuery();
                con.Close();
                _totalPrice = 0;//Resetting the total price to 0 so that it does not affect future transactions
                GenerateInvoice(un,bn,p,oid);
            }
            catch (Exception ex)
            {
                Console.Write("Exception: " + ex);
            }

        }
        protected static void GenerateInvoice(string user_name,string book_name,double book_price,string order_id) 
        {
            string emailAddress = "";
            SqlConnection con = new SqlConnection(strcon2);
            if (con.State==ConnectionState.Closed) 
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from master_user_table where user_name='"+user_name+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) 
            {
                while (dr.Read()) 
                {
                    emailAddress = dr["email"].ToString();//use on production server
                }
            }
            MailMessage mailMessage = new MailMessage("anewchapter96@gmail.com","anewchapter96@gmail.com");
            //mailMessage.Body = "YOUR INVOICE\n------------------------\nOrder Id:" + order_id + "\nBook name: " + book_name.ToUpper() + "\nPrice: $" + book_price + "\nTime:" + DateTime.Now;
            mailMessage.Body = "YOUR INVOICE\n---------------------------------------------------------------------------\nOrder Id |	Book name		|	Price	  |	Time\n"+order_id+ "    " +book_name+ "            " + book_price+ "        " + DateTime.Now+ "\n---------------------------------------------------------------------------\n                              Grand Total: $"+book_price;
            mailMessage.Subject = "Purchase invoice from 'A New Chapter'";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
            smtp.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "anewchapter96@gmail.com",
                Password = "i@mtesting9"
            };
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);
        }
        //Remove button
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try 
            {
                if (e.CommandName.Equals("Remove")) 
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State==ConnectionState.Closed) 
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("delete from sold_book_record where book_id='"+e.CommandArgument+"' and user_name='"+Session["user_name"]+"'",con);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("delete from checkout where book_id='"+e.CommandArgument+"' and user_name='"+Session["user_name"]+"'",con);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);//this will redirect to the same web form
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