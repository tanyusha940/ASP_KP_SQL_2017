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
    public class CountryRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["KP_2017"].ToString();
            con = new SqlConnection(constr);

        }

        public List<Countries> GetAllCountries()
        {
            connection();
            List<Countries> CountriesList = new List<Countries>();

            SqlCommand com = new SqlCommand("SelectCountry", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                CountriesList.Add
                (
                    new Countries
                    {
                        Country_ID = Convert.ToInt32(dr["Country_ID"]),
                        Country_Name = Convert.ToString(dr["Country_Name"])
                    }
               );
            }

            return CountriesList;
        }
    }
}