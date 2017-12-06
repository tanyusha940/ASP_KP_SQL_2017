using ASP.NET_KP_SQL_2017.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP.NET_KP_SQL_2017.Repository
{
    public class VisitorsCategoryRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["KP_2017"].ToString();
            con = new SqlConnection(constr);

        }
        
        public List<VisitorsCategory> GetAllVisitorsCategory()
        {
            connection();
            List<VisitorsCategory> VisitorsCategoryList = new List<VisitorsCategory>();


            SqlCommand com = new SqlCommand("Get_Visitor_Category", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
   
            foreach (DataRow dr in dt.Rows)
            {
                VisitorsCategoryList.Add
                (
                    new VisitorsCategory
                    {
                        Visitor_Category_ID = Convert.ToInt32(dr["Visitor_Category_ID"]),
                        Visitor_Category_Description = Convert.ToString(dr["Visitor_Category_Description"])
                    }
               );
            }

            return VisitorsCategoryList;
        }
    }
}