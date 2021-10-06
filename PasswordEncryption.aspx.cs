using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A_New_Chapter
{
    public partial class test : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected string ComputeSHA256Hash(string _rawData) 
        {
            using (SHA256 sha256 =SHA256.Create()) 
            {
                byte[] _bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(_rawData));
                StringBuilder _builder = new StringBuilder();
                for (int i=0;i<_bytes.Length;i++) 
                {
                    _builder.Append(_bytes[i].ToString("x2"));
                }
                return _builder.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text="Encrypted= "+EncryptString(TextBox1.Text.Trim());
        }
        public string DecryptString(string encrString) 
        {
            byte[] b;
            string decrypted;
            try 
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe) 
            {
                decrypted = "";
            }
            return decrypted;
            //Label2.Text = decrypted;
        }
        public string EncryptString(string strEncrypted) 
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            //Label1.Text = encrypted;
            return encrypted;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = "Decrypted= " +DecryptString(TextBox1.Text.Trim());
        }
    }
}