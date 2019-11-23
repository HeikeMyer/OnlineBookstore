using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;


namespace test.Controllers
{
    public class TestController: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
