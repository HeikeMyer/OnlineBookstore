using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using auth.test.Models;
using Microsoft.AspNetCore.Identity;

namespace auth.test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            /*var a = _signInManager.IsSignedIn(User);

            if (!a)
            {
                _signInManager.SignInAsync(new AppUser { Id = Guid.NewGuid().ToString(), UserName = "AAAA" }, false);
            }

            var b4 = _signInManager.IsSignedIn(User);*/

            var x =  _userManager.CreateAsync(new AppUser { Id = Guid.NewGuid().ToString(), UserName = "uuuuuuuuuuuuu" }, "psswd12dfJdl_88");
            var b = x.Result;
            //_userManager.Cr

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
