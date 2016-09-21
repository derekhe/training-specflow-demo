using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpecFlowDemoApp.Web.ViewModels;

namespace SpecFlowDemoApp.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginForm loginForm)
        {
            if (ModelState.IsValid)
            {
                if (ValidCredentials(loginForm))
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(loginForm.Username, false);

                    return RedirectToAction("Index", "Home");
                }

                ViewBag.LoginFailureMessage = "Invalid username or password.";
            }

            return View(loginForm);
        }

        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        private bool ValidCredentials(LoginForm loginForm)
        {
            return "testuser".Equals(loginForm.Username, StringComparison.OrdinalIgnoreCase)
                && "testpass".Equals(loginForm.Password, StringComparison.OrdinalIgnoreCase);
        }
    }
}
