using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KP_2017_itog.Models
{
    public class Countries
    {
        [Required]
        public int Country_ID { get; set; }

        [Required(ErrorMessage = "Страна не указана")]
        public string Country_Name { get; set; }
    }
}