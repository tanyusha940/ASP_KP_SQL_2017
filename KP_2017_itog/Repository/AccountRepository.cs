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
            com.Parameters.AddWithValue("@category", obj.Visitor_Category_ID.Visitor_Category_ID);
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
        public bool Login(Visitors obj)
        {
            connection();
            SqlCommand com = new SqlCommand("Login_Visitors", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", obj.Visitor_Name);
            com.Parameters.AddWithValue("@password", obj.Password);
            //com.Parameters.AddWithValue("@category", obj.Visitor_Category_ID);

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
