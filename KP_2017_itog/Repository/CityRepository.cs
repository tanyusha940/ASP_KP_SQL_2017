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
    public class CityRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["KP_2017"].ToString();
            con = new SqlConnection(constr);

        }

        public List<City> GetAllCity()
        {
            connection();
            List<City> CityList = new List<City>();

            SqlCommand com = new SqlCommand("SelectCity", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CityList.Add
                (
                    new City
                    {
                        City_ID = Convert.ToInt32(dr["City_ID"]),
                        City_Name = Convert.ToString(dr["City_Name"]),
                    }
               );
            }

            return CityList;
        }
    }
}