using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bookstore.site.Models;
using auth.identity;
using business.infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using mvc.core;

namespace bookstore.site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IUserRepository userRepository;
        //private readonly IRoleRepository roleRepository;
        //private readonly SignInManager<IdentityDto> signInManager;
        private readonly IAuthOperation authOperation;

        public HomeController(ILogger<HomeController> logger, IAuthOperation um)
        {
            _logger = logger;
            authOperation = um;
        }

        public IActionResult Index()
        {
            /*var a = signInManager.IsSignedIn(User);

            signInManager.SignInAsync(new IdentityDto { Login = "hhhhhhhhhhhhhhhhhhhhhhhhhhhhh", UserId = Guid.Parse("FDC03F15-EFC9-4BFC-A991-ACE17D8E9E26") }, false);

            var a1 = signInManager.IsSignedIn(User);

            signInManager.SignOutAsync();

            var a2 = signInManager.IsSignedIn(User);*/

            authOperation.Test();

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
