using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace A_New_Chapter.DAL
{
    public class Interaction 
    {
        public string comment_CommentId { get; set; }
        public string Commenter { get; set; }
        public string CommentText { get; set; }
        public string CommentTime { get; set; }
        public string ReplyId { get; set; }
        public string Replier { get; set; }
        public string ReplyText { get; set; }
        public string ReplyTime { get; set; }
        public string reply_CommentId { get; set; }
    }
    public class DataAccessLayer
    {
        public static List<Interaction> GetAllInteractions() 
        {
            List<Interaction> _listinter = new List<Interaction>();
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == System.Data.ConnectionState.Closed) 
            {
                con.Open();
            }
            SqlCommand cmd1 = new SqlCommand("select * from comment join reply on comment.comment_id=reply.comment_id", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.HasRows)
            {
                while (dr1.Read())
                {
                    Interaction _inter = new Interaction();
                    _inter.comment_CommentId = dr1["comment_id"].ToString();
                    _inter.Commenter = dr1["commenter"].ToString();
                    _inter.CommentText = dr1["comment_text"].ToString();
                    _inter.CommentTime = dr1["comment_time"].ToString();
                    _inter.ReplyId = dr1["reply_id"].ToString();
                    _inter.Replier = dr1["replier"].ToString();
                    _inter.ReplyText = dr1["reply_text"].ToString();
                    _inter.ReplyTime = dr1["reply_time"].ToString();
                    _inter.reply_CommentId = dr1["comment_id"].ToString();
                    _listinter.Add(_inter);
                }
            }
            dr1.Close();
            //SqlCommand cmd2 = new SqlCommand("select * from comment", con);
            //SqlDataReader dr2 = cmd2.ExecuteReader();
            //if (dr2.HasRows) 
            //{
            //    while (dr2.Read()) 
            //    {
            //        Interaction _inter = new Interaction();
            //        _inter.comment_CommentId = dr2["comment_id"].ToString();
            //        _inter.Commenter = dr2["commenter"].ToString();
            //        _inter.CommentText = dr2["comment_text"].ToString();
            //        _inter.CommentTime = dr2["comment_time"].ToString();
            //        _listinter.Add(_inter);
            //    }
            //}
            //dr2.Close();
            return _listinter;
        }
    }
}