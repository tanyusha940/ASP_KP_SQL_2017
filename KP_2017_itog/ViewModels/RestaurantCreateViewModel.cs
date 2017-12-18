using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP_2017_itog.ViewModels
{
    public class RestaurantCreateViewModel
    {

        public int Restaurant_ID { get; set; }

        public int City_ID { get; set; }

        public string Addresses { get; set; }

        public int Star { get; set; }

        public string Restaurant_Name { get; set; }

        public string Restaurant_Description { get; set; }

        public string Opening_Hours { get; set; }

        public string Other_Details { get; set; }

        public int TypeKitchen { get; set; }
    }
}