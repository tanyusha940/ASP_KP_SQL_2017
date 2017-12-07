using KP_2017_itog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KP_2017_itog.Repository
{
    public class AccountRepository
    {
        private SqlConnection con;


        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["KP_2017"].ToString();
            con = new SqlConnection(constr);
        }

        public bool RegisterVisitor(Visitors obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Register_Visitor", con);
           // SqlCommand catVis = new SqlCommand("Get_Visitor_Category")
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", obj.Visitor_Name);
            com.Parameters.AddWithValue("@category", obj.Visitor_Category_ID);
            com.Parameters.AddWithValue("@password", obj.Password);

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
        //public List<Visitors> Login(Visitors obj)
        //{
        //    connection();
        //    List<Visitors> VisitorsList = new List<Visitors>();
        //    SqlCommand com = new SqlCommand("Login_Visitors", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter da = new SqlDataAdapter(com);
        //    DataTable dt = new DataTable();

        //    con.Open();
        //    da.Fill(dt);
        //    con.Close();
        //    foreach(DataRow dr in dt.Rows)
        //    {
        //        new Visitors
        //        {

        //        };
        //    }
        //    return true;
        //}
    }
}
