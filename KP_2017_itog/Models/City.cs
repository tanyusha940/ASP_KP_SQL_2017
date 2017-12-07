using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KP_2017_itog.Models
{
    public class City
    {
        [Required]
        public int City_ID { get; set; }

        [Required(ErrorMessage = "Город не указан")]
        public string City_Name { get; set; }

        [Required]
        public int Country_ID { get; set; }
    }
}