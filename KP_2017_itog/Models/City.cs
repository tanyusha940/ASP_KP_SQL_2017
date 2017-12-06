using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_KP_SQL_2017.Models
{
    public class City
    {
        public int City_ID { get; set; }
        [Required(ErrorMessage = "City name is required")]
        public string City_Name { get; set; }
        public Countries Country_ID { get; set; }
    }
}