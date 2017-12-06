using ASP.NET_KP_SQL_2017.Models;
using ASP.NET_KP_SQL_2017.Repository;
using KP_2017_itog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KP_2017_itog.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        VisitorsCategoryRepository visitorsCategoryRepository = new VisitorsCategoryRepository();

        [HttpPost]
        public ActionResult Register(Visitors visitor)
        {
            visitorsCategoryRepository.GetAllVisitorsCategory();
            AccountRepository accountRepository = new AccountRepository();

            if (accountRepository.RegisterVisitor(visitor))
            {
                ViewBag.Message = "Visitor log out successfully";
            }


            return RedirectToAction("RegisterVisitor");
        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(Visitors visitor, string returnUrl)
        {
            AccountRepository accountRepository = new AccountRepository();
            return View(visitor);
        }
    }
}