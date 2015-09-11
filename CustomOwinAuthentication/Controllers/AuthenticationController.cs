using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CustomOwinAuthentication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using SecurityAddons;

namespace CustomOwinAuthentication.Controllers
{
    public class AuthenticationController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private CustomUserManager userManager;

        public AuthenticationController()
        {
            userManager = new CustomUserManager();
        }

        //
        // GET: /Authentication/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userManager.GetUserIfValid(model.UserName, 
                    model.Password);
                if (user != null)
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(user.BuildIdentity());
                    return RedirectToAction("index", "home");
                }
            }
            return View(model);
        }


        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }

    }
}