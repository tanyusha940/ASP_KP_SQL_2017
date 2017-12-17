using KP_2017_itog.Models;
using KP_2017_itog.Repository;
using KP_2017_itog.ViewModels;
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
        AccountRepository accountRepository = new AccountRepository();
        public CommentController()
        {
            visitorsCommentsRepository = new VisitorsCommentsRepository();
            accountRepository = new AccountRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void AddComment(CommentViewModel model, int restaurantId/*, int userId*/)
        {
            //var user = accountRepository.GetAllVisitor().Find(x => x.Visitor_ID == userId);
            visitorsCommentsRepository.AddComment(model);
            
        }
        public ActionResult GetComment(int id)
        {
            List<VisitorsComments> visitorComments = new List<VisitorsComments>();
            var model = visitorsCommentsRepository.GetAllComments().Find(x => x.Visitor_ID == id);
            return View(model);
        }
    }
}