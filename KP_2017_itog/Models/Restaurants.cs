using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_KP_SQL_2017.Models
{
    public class Restaurants
    {
        public int Restaurant_ID { get; set; }

        public City City_ID { get; set; }

        [Required(ErrorMessage = "Adress is required.")]
        public string Addresses { get; set; }

        [Required(ErrorMessage = "Runking Number is required.")]
        public float Ranking_Number { get; set; }

        [Required(ErrorMessage = "Restaurant name is required.")]
        public string Restaurant_Name { get; set; }
        public string Restaurant_Description { get; set; }

        public string Opening_Hours { get; set; }

        public string Other_Details { get; set; }

        public string Add_geom { get; set; }


    }
}