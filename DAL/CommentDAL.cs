using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace A_New_Chapter.DAL
{
    public class Comment 
    {
        public string CommentId { get; set; }
        public string Commenter { get; set; }
        public string CommentText { get; set; }
        public string CommentTime { get; set; }
    }
    public class CommentDAL
    {
        public static List<Comment> GetAllCommentData() 
        {
            List<Comment> _listcmnt = new List<Comment>();
            string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            if (con.State==System.Data.ConnectionState.Closed) 
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from comment",con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) 
            {
                while (dr.Read()) 
                {
                    Comment _comment = new Comment();
                    _comment.CommentId = dr["comment_id"].ToString();
                    _comment.Commenter = dr["commenter"].ToString();
                    _comment.CommentText = dr["comment_text"].ToString();
                    _comment.CommentTime = dr["comment_time"].ToString();
                    _listcmnt.Add(_comment);
                }
            }
            return _listcmnt;
        }

    }
}