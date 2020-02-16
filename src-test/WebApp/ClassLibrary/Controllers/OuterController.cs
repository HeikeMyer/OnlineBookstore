using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using RazorClassLibrary.Models;

namespace ClassLibrary.Controllers
{
    public class OuterController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Hi()
        {
            var model = new OuterModel { Name = "Jessica", Value = "Rabbit" };
            return View(model);
        }

        public ActionResult Hello()
        {
            var model = new HelloModel { A = "Jessica", B = 55 };
            return View(model);
        }
    }
}
