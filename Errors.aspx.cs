using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class Errors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control myNavbar = this.Page.Master.FindControl("navbar1");
            Control myFooter = this.Page.Master.FindControl("footer1");
            if (myNavbar!=null) 
            {
                myNavbar.Visible = true;
            }
            if (myFooter != null)
            {
                myFooter.Visible = false;
            }
        }
    }
}