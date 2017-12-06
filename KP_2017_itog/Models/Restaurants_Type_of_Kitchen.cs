using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP_2017_itog.Models
{
    public class Restaurants_Type_of_Kitchen
    {
        public Restaurants Restaurant_ID { get  ; set; }
        public Ref_Types_of_Kitchen Kitchen_Type_Code { get; set; }
    }
}