using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class homepage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].Equals("user"))
                {
                    Button2.Visible = true;
                    member_management.Visible = false;
                    author_management.Visible = false;
                    book_inventory.Visible = false;
                    unpaid_authors.Visible = false;
                    book_review.Visible = false;
                    admin_login.Visible = true;
                    book_shelf.Visible = true;
                    upload_book.Visible = false;
                }
                else if (Session["role"].Equals("author"))
                {
                    Button2.Visible = false;
                    member_management.Visible = false;
                    author_management.Visible = false;
                    book_inventory.Visible = false;
                    unpaid_authors.Visible = false;
                    book_review.Visible = false;
                    admin_login.Visible = true;
                    book_shelf.Visible = false;
                    upload_book.Visible = true;
                }
                else if (Session["role"].Equals("admin"))
                {
                    Button2.Visible = false;
                    member_management.Visible = true;
                    author_management.Visible = true;
                    book_inventory.Visible = true;
                    unpaid_authors.Visible = true;
                    book_review.Visible = true;
                    admin_login.Visible = false;
                    book_shelf.Visible = false;
                    upload_book.Visible = false;
                }
            }
            else
            {
                Button2.Visible = true;
                member_management.Visible = false;
                author_management.Visible = false;
                book_inventory.Visible = false;
                unpaid_authors.Visible = false;
                book_review.Visible = false;
                admin_login.Visible = true;
                book_shelf.Visible = false;
                upload_book.Visible = false;
            }
        }
        //Be an author
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuthorRegisterPage.aspx");
        }

        protected void member_management_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminMemberManagementPage.aspx");
        }

        protected void author_management_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminAuthorManagementPage.aspx");
        }

        protected void book_inventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookInventory.aspx");
        }

        protected void unpaid_authors_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AuthorPaymentPage.aspx");
        }

        protected void book_review_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminBookReview.aspx");
        }

        protected void admin_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLoginPage.aspx");
        }

        protected void book_shelf_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookShelf.aspx");
        }

        protected void upload_book_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookUploadPage.aspx");
        }
    }
}