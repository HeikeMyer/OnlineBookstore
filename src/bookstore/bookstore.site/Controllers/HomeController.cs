using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bookstore.site.Models;
using business.infrastructure.Repositories;
using System;

namespace bookstore.site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository u, IRoleRepository r)
        {
            _logger = logger;
            userRepository = u;
            roleRepository = r;
        }

        public IActionResult Index()
        {
            var user = userRepository.GetObject(Guid.Parse("9B2F2BFF-E087-459D-9F60-7739C2CAC09E"));
            var r1 = roleRepository.GetObject(Guid.Parse("3230E51D-020A-4644-9152-21B82BF54219"));
            var r2 = roleRepository.GetObject("ORDER_MANAGER");

            var rs = roleRepository.GetCollection(user.Id);

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
