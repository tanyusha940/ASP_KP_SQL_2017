using KP_2017_itog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KP_2017_itog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Ref_Types_of_KitchenRepository objType = new Ref_Types_of_KitchenRepository();
            objType.GetAllTypeOfKitchen();
            VisitorsCategoryRepository objCateg = new VisitorsCategoryRepository();
            objCateg.GetAllVisitorsCategory();
            CountryRepository objCountry = new CountryRepository();
            objCountry.GetAllCountries();
            CityRepository objCity = new CityRepository();
            objCity.GetAllCity();
        }
    }
}
