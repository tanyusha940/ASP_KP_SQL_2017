using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_KP_SQL_2017.Models
{
    public class Restaurants_Type_of_Kitchen
    {
        public Restaurants Restaurant_ID { get  ; set; }
        public Ref_Types_of_Kitchen Kitchen_Type_Code { get; set; }
    }
}