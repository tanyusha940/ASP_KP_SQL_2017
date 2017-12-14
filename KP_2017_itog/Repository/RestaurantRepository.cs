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
    public class RestaurantRepository
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["KP_2017"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddRestaurant(Restaurants restaurants, Restaurants_Type_of_Kitchen type)
        {

            connection();
            SqlCommand com = new SqlCommand("Post_Add_Restaurant", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@cityId", restaurants.City_ID);
            com.Parameters.AddWithValue("@address", restaurants.Addresses);
            com.Parameters.AddWithValue("@name", restaurants.Restaurant_Name);
            com.Parameters.AddWithValue("@description", restaurants.Restaurant_Description);
            com.Parameters.AddWithValue("@hours", restaurants.Opening_Hours);
            com.Parameters.AddWithValue("@details", restaurants.Other_Details);
            //         com.Parameters.AddWithValue("@geom", restaurants.Add_geom);
            com.Parameters.AddWithValue("@typeKitchenId", type.Kitchen_Type_Code);
            com.Parameters.AddWithValue("@resId", type.Restaurant_ID);


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

        public List<Restaurants> GetAllRestaurant()
        {
            connection();
            List<Restaurants> RestaurantsList = new List<Restaurants>();

            SqlCommand com = new SqlCommand("SelectRestaurant", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                RestaurantsList.Add(

                    new Restaurants
                    {   
                        Restaurant_ID = Convert.ToInt32(dr["Restaurant_ID"]),
                        Restaurant_Name = Convert.ToString(dr["Restaurant_Name"]),
                        Restaurant_Description = Convert.ToString(dr["Restaurant_Description"]),
                        Addresses = Convert.ToString(dr["Addresses"]),
                        Opening_Hours = Convert.ToString(dr["Opening_Hours"]),
                        Other_Details = Convert.ToString(dr["Other_Details"])
                    });
            }
            return RestaurantsList;
        }

        public bool UpdateRestaurant(Restaurants obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateRestaurant", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@resId", obj.Restaurant_ID);
            com.Parameters.AddWithValue("@description", obj.Restaurant_Description);
            com.Parameters.AddWithValue("@hours", obj.Opening_Hours);
            com.Parameters.AddWithValue("@details", obj.Other_Details);

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
        public bool DeleteRestaurant(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteRestaurant", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@resId", Id);

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