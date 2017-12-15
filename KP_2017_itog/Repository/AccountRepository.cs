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
            command.Parameters.AddWithValue("@userRole", "User");


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

        public List<Visitors> GetAllVisitor()
        {
            connection();
            List<Visitors> VisitorList = new List<Visitors>();
            
            SqlCommand command = new SqlCommand("GetVisitors", connect);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            connect.Open();
            da.Fill(dt);
            connect.Close();

            foreach (DataRow dr in dt.Rows)
            {

                VisitorList.Add(
                    new Visitors
                    {
                        Visitor_ID = Convert.ToInt32(dr["Visitor_ID"]),
                        Visitor_Name = Convert.ToString(dr["Visitor_Name"]),
                        Visitor_Category_ID = Convert.ToInt32(dr["Visitor_ID"]),
                        Visitor_Description = Convert.ToString(dr["Visitor_Description"])
                    });
            }
            
            connect.Close();
            return VisitorList;
        }
    }
}
