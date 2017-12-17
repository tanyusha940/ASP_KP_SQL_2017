using KP_2017_itog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP_2017_itog.ViewModels
{
    public class RestaurantViewModel
    {
        public List<City> City { get; set; }
        public List<Ref_Types_of_Kitchen> TypeKitchen { get; set; }
        public Restaurants Restaurants { get; set; }
        public List<Countries> Country { get; set; }
        public RestaurantCreateViewModel RestaurantCreateViewModel { get; set; }
    }
}