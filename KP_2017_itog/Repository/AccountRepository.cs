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
        public bool Login(string Visitor_Name, string Password)
        {
            connection();
            SqlCommand command = new SqlCommand("Login_Visitors", connect);
            connect.Open();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", Visitor_Name);
            command.Parameters.AddWithValue("@password", Password);
            SqlDataReader dr = command.ExecuteReader(CommandBehavior.SingleRow);

            if (!dr.HasRows)
            {
                connect.Close();
                return false;
            }
            connect.Close();
            return true;
        }
    }
}
