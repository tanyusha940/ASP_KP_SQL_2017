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

        public ActionResult AddComment()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(CommentViewModel model)
        {
            //var user = accountRepository.GetAllVisitor().Find(x => x.Visitor_ID == userId);
            visitorsCommentsRepository.AddComment(model);
            return View();
        }
        public ActionResult GetComment()
        {
            List<VisitorsComments> visitorComments = new List<VisitorsComments>();
            var model = visitorsCommentsRepository.GetAllComments();
            return View(model);
        }
    }
}