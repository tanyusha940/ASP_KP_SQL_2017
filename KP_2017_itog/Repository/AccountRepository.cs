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
        public Visitors Login(Visitors obj)
        {
            connection();
            con.Open();
            SqlCommand com = con.CreateCommand();
            com.CommandText = "select *from Visitors where Visitor_Name = '" + obj.Visitor_Name + "' and Visitor_Password = '" + obj.Password + "'";
            SqlDataReader dataReader = com.ExecuteReader();

            int itemIndex = 0;
            while (dataReader.Read())
            {
                itemIndex++;
            }
            //if (itemIndex == 0)
            //{
            //    return false;
            //}
            return obj;

        }
    }
}
