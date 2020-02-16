//using auth.identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace auth.site.Controllers
{
    //[Authorize]
    public class SignOutController : Controller
    {
        //private IAuthOperation AuthOperation { get; set; }

        public SignOutController()
        {
           // AuthOperation = authOperation;
        }
        public ActionResult Index()
        {
            var a = HttpContext.User;
            //AuthOperation.SignOut();
            var b = HttpContext.User;

            return new EmptyResult();
        }
    }
}
