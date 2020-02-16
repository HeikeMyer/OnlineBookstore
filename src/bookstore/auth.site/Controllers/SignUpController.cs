using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace auth.site.Controllers
{
    public class SignUpController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
