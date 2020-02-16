using System;
using System.Collections.Generic;
using System.Text;
using auth.site.Models;
using Microsoft.AspNetCore.Mvc;

namespace auth.site.Controllers
{
    public class SignUpController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //var model = new SignUpModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SignUpModel model)
        {
            if (ModelState.IsValid)
            {

            }

            return View(model);
        }
    }
}
