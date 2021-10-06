using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SHA256 sHA256 = SHA256.Create()) 
            {
                byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(TextBox1.Text.Trim()));
                StringBuilder stringBuilder = new StringBuilder();
                for (int i=0;i<bytes.Length;i++) 
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                Label1.Text = "Hash value is " + stringBuilder.ToString();
            }

        }
    }
}