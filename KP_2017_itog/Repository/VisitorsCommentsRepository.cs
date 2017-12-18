using KP_2017_itog.Models;
using KP_2017_itog.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KP_2017_itog.Repository
{
    public class VisitorsCommentsRepository
    {
        private SqlConnection con;
  
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["KP_2017"].ToString();
            con = new SqlConnection(constr);
        }
 
        public bool AddComment(Restaurants obj,int? resId, int? userId)
        {
            connection();
            SqlCommand com = new SqlCommand("AddComment", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@restId", resId);
            com.Parameters.AddWithValue("@visitorId", userId);
            com.Parameters.AddWithValue("@text", obj.CommentText);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }    

        public List<VisitorsComments> GetAllComments(int? resId)
        {
            
            connection();
            List<VisitorsComments> visitorsComments = new List<VisitorsComments>();

            SqlCommand com = new SqlCommand("Get_Comments", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@resId", resId);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
   
            foreach (DataRow dr in dt.Rows)
            {
                visitorsComments.Add(
                    new VisitorsComments
                    {
                        Comment_Date = Convert.ToString(dr["Comment_Date"]),
                        CommentText = Convert.ToString(dr["CommentText"])                      
                    });
            }
            return visitorsComments;
        }
     
        public bool DeleteComment(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteComment", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@commId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}