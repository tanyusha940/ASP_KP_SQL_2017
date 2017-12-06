using KP_2017_itog.Models;
using KP_2017_itog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KP_2017_itog.Controllers
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
