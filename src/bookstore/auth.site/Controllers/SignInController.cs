//using auth.identity.Interfaces;
using auth.site.Models;
using business.infrastructure.Operations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using mvc.core;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace auth.site.Controllers
{
    public class SignInController : BaseController
    {
        //private IAuthOperation AuthOperation { get; set; }

        public SignInController(IUserOperation userOperation) : base(userOperation)
        {

        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SignInModel model)
        {         
            if (!ModelState.IsValid)
                return View(model);

            if (model.Email == "admin@book.com" && model.Password == "password")
            {

                //Create the identity for the user  
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, model.Email)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            return new EmptyResult();

        }
    }
}
