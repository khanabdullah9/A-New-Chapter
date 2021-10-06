using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace A_New_Chapter.DAL
{
    public class Reply 
    {
        public string ReplyId { get; set; }
        public string Replier { get; set; }
        public string ReplyText { get; set; }
        public string ReplyTime { get; set; }
        public string CommentId { get; set; }
    }
    public class ReplyDAL
    {
        public static List<Reply> GetAllReplyData()
        {
            List<Reply> _listreply = new List<Reply>();
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from reply", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) 
            {
                while (dr.Read()) 
                {
                    Reply _reply = new Reply();
                    _reply.ReplyId = dr["reply_id"].ToString();
                    _reply.Replier = dr["replier"].ToString();
                    _reply.ReplyText = dr["reply_text"].ToString();
                    _reply.ReplyTime = dr["reply_time"].ToString();
                    _reply.CommentId = dr["comment_id"].ToString();
                    _listreply.Add(_reply);
                }
            }
            return _listreply;
        }
    }
}