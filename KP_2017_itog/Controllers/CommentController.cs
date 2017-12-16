using KP_2017_itog.Models;
using KP_2017_itog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KP_2017_itog.Controllers
{
    public class CommentController : Controller
    {
        VisitorsCommentsRepository visitorsCommentsRepository = new VisitorsCommentsRepository();

        public CommentController()
        {
            visitorsCommentsRepository = new VisitorsCommentsRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        //public  ActionResult AddComment (VisitorsComments model,int restaurantId)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (visitorsCommentsRepository.AddComment(model))
        //        {
        //            TempData["message"] = $"Комментарий успешно добавлен";
        //            return RedirectToAction("GetAllRestaurants", "Restaurant");
        //        }
        //    }
        //    return View();
        //}
    }
}