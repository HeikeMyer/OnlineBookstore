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

namespace bookstore.site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly SignInManager<IdentityDto> signInManager;
        private readonly UserManager<IdentityDto> userManager;

        public HomeController(ILogger<HomeController> logger, IUserRepository u, IRoleRepository r, SignInManager<IdentityDto> si, UserManager<IdentityDto> um)
        {
            _logger = logger;
            userRepository = u;
            roleRepository = r;
            signInManager = si;
            userManager = um;
        }

        public IActionResult Index()
        {
            var a = signInManager.IsSignedIn(User);

            var b = signInManager.SignInAsync(new IdentityDto { Login = "admin" }, false);
            var c = b.IsCompletedSuccessfully;

            /*var user = userRepository.GetObject(Guid.Parse("9B2F2BFF-E087-459D-9F60-7739C2CAC09E"));
            var r1 = roleRepository.GetObject(Guid.Parse("3230E51D-020A-4644-9152-21B82BF54219"));
            var r2 = roleRepository.GetObject("ORDER_MANAGER");

            var rs = roleRepository.GetCollection(user.Id);*/
            //userManager.CreateAsync(new IdentityDto { Login = "hhhh" }, "kuku88slask00islknsma");

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
