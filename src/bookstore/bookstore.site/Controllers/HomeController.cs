using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bookstore.site.Models;
using auth.identity.Interfaces;
using business.infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using mvc.core;

namespace bookstore.site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthOperation _authOperation;

        public HomeController(ILogger<HomeController> logger, IAuthOperation authOperation)
        {
            _logger = logger;
            _authOperation = authOperation;
        }

        public IActionResult Index()
        {            
            //_authOperation.Create("user_test", "test@test.com", "jajdal776_UKna", firstName:"Test", secondName:"TeEEst");

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
