using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KP_2017_itog.Models
{
    public class Restaurants_Type_of_Kitchen
    {
        [Required]
        public int Restaurant_ID { get  ; set; }

        [Required]
        public int Kitchen_Type_Code { get; set; }
    }
}