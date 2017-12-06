using ASP.NET_KP_SQL_2017.Models;
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
 
        public bool AddComment(VisitorsComments obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddComment", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@date", obj.Comment_Date);
            com.Parameters.AddWithValue("@restId", obj.Restaurant_ID);
            com.Parameters.AddWithValue("@visitorId", obj.Visitor_ID);

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
        public List<VisitorsComments> GetAllComments()
        {
            connection();
            List<VisitorsComments> visitorsComments = new List<VisitorsComments>();


            SqlCommand com = new SqlCommand("Get_Comments", con);
            com.CommandType = CommandType.StoredProcedure;
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
                        Comment_Date = Convert.ToDateTime(dr["date"]),
                        Comment_Text = Convert.ToString(dr["text"])
                       
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