using KP_2017_itog.Services;
using KP_2017_itog.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KP_2017_itog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            ViewBag.Message = "Your application description page.";
            var result = await InitializationBingMaps.InitializeBingMap();
            var point = result.Succeeded.Entities[0].GeocodeResponse[0].GeocodePoint[0];
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            return View(new GoePointViewModel
            {
                Lat = point.Latitude.ToString(nfi),
                Long = point.Longitude.ToString(nfi)
            });
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}