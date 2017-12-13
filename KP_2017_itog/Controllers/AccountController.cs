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
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Visitors user = new Visitors() { Visitor_Name = model.Visitor_Name, Password = model.Password };

            user = accountRepository.Login(user);

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.Visitor_Name, false);
                var authTicket = new FormsAuthenticationTicket(1, user.Visitor_Name, DateTime.Now, DateTime.Now.AddMinutes(20), false,model.Password);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return Redirect("/Home/Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }
        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
              
            }
        }
    }
}