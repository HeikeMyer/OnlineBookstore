using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bookstore.site.Models;
using business.infrastructure.Repositories;
using business.infrastructure.Operations;
using business.entity.Entities;

namespace bookstore.site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*var res = HttpContext.RequestServices;
            
            var a1 = a.Hello();*/
            var b = (IUserOperation)HttpContext.RequestServices.GetService(typeof(IUserOperation));
            var b1 = b.Hi();

            var a = (IUserRepository)HttpContext.RequestServices.GetService(typeof(IUserRepository));
            var u = new User { Id = Guid.NewGuid(), Login = "user444", Password = "hsjakjxd", Email = "jadjk" };
            a.Add(u);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
