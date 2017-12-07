using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KP_2017_itog.Models
{
    public class Ref_Types_of_Kitchen
    {
        [Required]
        public int Kitchen_Type_Code { get; set; }

        [Required(ErrorMessage = "Тип кухни не указан")]
        public string Kitchen_Type_Description { get; set; }
    }
}