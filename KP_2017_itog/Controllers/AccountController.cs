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
    public class AccountController : Controller
    {
        private readonly AccountRepository accountRepository;
        private readonly VisitorsCategoryRepository visitorsCategoryRepository;

        public AccountController()
        {
            accountRepository = new AccountRepository();
            visitorsCategoryRepository = new VisitorsCategoryRepository();
        }

        // GET: Account
        public ActionResult Register()
        {
            var viewModel = new RegistrationViewModel()
            {
                Categories = visitorsCategoryRepository.GetAllVisitorsCategory()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Register(Visitors visitor)
        {
            if (ModelState.IsValid)
            { 
                if (accountRepository.RegisterVisitor(visitor))
                {
                    ViewBag.Message = "Visitor log out successfully";
                }
            }
            return Redirect("/Home/Index");
        }


        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public ActionResult Login(Visitors model, string returnUrl)
        {
            AccountRepository accountRepository = new AccountRepository();
            if (ModelState.IsValid)
            {
                
            }
            return View();
        }
    }
}