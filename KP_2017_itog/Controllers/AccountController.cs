using KP_2017_itog.Models;
using KP_2017_itog.Repository;
using KP_2017_itog.ViewModels;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

        [AllowAnonymous]
        public ActionResult Register()
        {
            var viewModel = new RegistrationViewModel()
            {
                Categories = visitorsCategoryRepository.GetAllVisitorsCategory()
            };
            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Visitors visitor)
        {
            if (ModelState.IsValid)
            {
                if(accountRepository.RegisterVisitor(visitor))
                {
                    TempData["message"] = $"Пользователь успешно создан";
                    return RedirectToAction("Login", "Account");
                }
                TempData["message"] = $"Пользователь с таким именем уже существует!";
            }
            return View(visitor);
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = accountRepository.Login(model.Visitor_Name, model.Password);

            if (user)
            {
                CreateCookie(model.Visitor_Name, model.Password);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #region Helpers

        public void CreateCookie(string login, string password)
        {
            var authTicket = new FormsAuthenticationTicket(1, login, DateTime.Now,
                DateTime.Now.AddMinutes(20), false, password);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authCookie);
        }

        #endregion
    }
}