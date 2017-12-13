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
    public class AccountRepository
    {
        private SqlConnection connect;


        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["KP_2017"].ToString();
            connect = new SqlConnection(constr);
        }

        public bool RegisterVisitor(Visitors obj)
        {
            connection();
            SqlCommand command = new SqlCommand("Register_Visitor", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", obj.Visitor_Name);
            command.Parameters.AddWithValue("@category", obj.Visitor_Category_ID);
            command.Parameters.AddWithValue("@password", obj.Password);


            connect.Open();
            int i = command.ExecuteNonQuery();
            connect.Close();
            return true;
        }
        public Visitors Login(Visitors obj)
        {
            connection();
            connect.Open();
            SqlCommand com = connect.CreateCommand();
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
