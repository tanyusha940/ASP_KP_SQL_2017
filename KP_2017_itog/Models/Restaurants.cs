using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KP_2017_itog.Models
{
    public class Restaurants
    {
        [Required]
        public int Restaurant_ID { get; set; }
        [Required]
        public int City_ID { get; set; }

        [Required(ErrorMessage = "Адрес не указан")]
        public string Addresses { get; set; }

        //[Required(ErrorMessage = "Рейтинг не указан")]
        public float Ranking_Number { get; set; }

        [Required(ErrorMessage = "Имя ресторана не указано")]
        public string Restaurant_Name { get; set; }

        public string Restaurant_Description { get; set; }

        public string Opening_Hours { get; set; }

        public string Other_Details { get; set; }

        public string Add_geom { get; set; }


    }
}