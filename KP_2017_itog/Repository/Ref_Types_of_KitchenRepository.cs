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
    public class Ref_Types_of_KitchenRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["KP_2017"].ToString();
            con = new SqlConnection(constr);

        }

        public List<Ref_Types_of_Kitchen> GetAllTypeOfKitchen()
        {
            connection();
            List<Ref_Types_of_Kitchen> TypeKitchenList = new List<Ref_Types_of_Kitchen>();

            SqlCommand com = new SqlCommand("Get_Ref_Type_of_Kitchen", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                TypeKitchenList.Add
                (
                    new Ref_Types_of_Kitchen
                    {
                        Kitchen_Type_Description = Convert.ToString(dr["Kitchen_Type_Description"])

                    }
               );
            }

            return TypeKitchenList;
        }
    }
}