using ASP.NET_KP_SQL_2017.Models;
using ASP.NET_KP_SQL_2017.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_KP_SQL_2017.Controllers
{
    public class VisitorCategoryController : Controller
    {
        [HttpGet]
        public ActionResult GetAllVisitorsCategory()
        {
            VisitorsCategoryRepository visitorsCategoryRepository = new VisitorsCategoryRepository();
            ModelState.Clear();
            return View(visitorsCategoryRepository.GetAllVisitorsCategory());
        }
        public ActionResult AllVisitorsCategory()
        {
            return View();
        }
    }
}
