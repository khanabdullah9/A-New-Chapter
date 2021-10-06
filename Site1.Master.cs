using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton4.Click += new EventHandler(LinkButton4_Click);
            if (Session["role"] == null)
            {
                LinkButton1.Visible = true;//bookstore button
                LinkButton2.Visible = true;//user sign up
                LinkButton3.Visible = false;//Upload
                LinkButton5.Visible = true;//admin login
                LinkButton6.Visible = false;//admin member management
                LinkButton7.Visible = false;//admin author management
                LinkButton4.Visible = false;//logout button
                dropdownMenuButton.Visible = true;//login dropdown in navbar
                LinkButton8.Visible = false;//Your cart
                LinkButton9.Visible = false;//book review
                LinkButton10.Visible = false;//book inventory
                LinkButton11.Visible = false;//Book shelf
                LinkButton12.Visible = false;//Unpaid Authors
            }
            else if (Session["role"].Equals("user"))
            {
                LinkButton1.Visible = true;//bookstore button
                LinkButton2.Visible = false;//user sign up
                LinkButton3.Visible = false;//upload
                //LinkButton5.Visible = true;//admin login
                LinkButton6.Visible = false;//admin member management
                LinkButton7.Visible = false;//admin author management
                LinkButton4.Visible = true;//logout button
                dropdownMenuButton.Visible = false;//login dropdown in navbar
                LinkButton8.Visible = false;//Your cart
                LinkButton9.Visible = false;//book review
                LinkButton10.Visible = false;//book inventory
                LinkButton11.Visible = true;//Book shelf
                LinkButton12.Visible = false;//Unpaid Authors
            }
            else if (Session["role"].Equals("admin")) 
            {
                LinkButton1.Visible = true;//bookstore button
                LinkButton2.Visible = false;//user sign up
                LinkButton3.Visible = false;//Upload
                LinkButton5.Visible = false;//admin login
                LinkButton6.Visible = true;//admin member management
                LinkButton7.Visible = true;//admin author management
                LinkButton4.Visible = true;//logout button
                dropdownMenuButton.Visible = false;//login dropdown in navbar
                LinkButton8.Visible = false;//Your cart
                LinkButton9.Visible = true;//book review
                LinkButton10.Visible = true;//book inventory
                LinkButton11.Visible = false;//Book shelf
                LinkButton12.Visible = true;//Unpaid Authors
            }
            else if (Session["role"].Equals("author"))
            {
                LinkButton1.Visible = true;//bookstore button
                LinkButton2.Visible = false;//user sign up
                LinkButton3.Visible = true;//upload
                //LinkButton5.Visible = true;//admin login
                LinkButton6.Visible = false;//admin member management
                LinkButton7.Visible = false;//admin author management
                LinkButton4.Visible = true;//logout button
                dropdownMenuButton.Visible = false;//login dropdown in navbar
                LinkButton8.Visible = false;//Your cart
                LinkButton9.Visible = false;//book review
                LinkButton10.Visible = false;//book inventory
                LinkButton11.Visible = false;//book shelf
                LinkButton12.Visible = false;//Unpaid Authors
            }

        }
        //for bookstore button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookstorePage.aspx");
        }
        //user sign up Page
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserSignUpPage.aspx");
        }
        //upload button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookUploadPage.aspx");
        }
        //for admin login
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLoginPage.aspx");
        }
        //Admin member management page
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminMemberManagementPage.aspx");
        }
        //Admin author management page
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminAuthorManagementPage.aspx");
        }
        //logout button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //Session.Remove("role");
            Session["role"] = null;
            Response.Redirect("~/homepage.aspx");
        }
        //Your cart
        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddToCartPage.aspx");
        }
        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminBookReview.aspx");
        }
        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookInventory.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookShelf.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuthorPaymentPage.aspx");
        }
    }
}   