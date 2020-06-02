using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CuddlyWombat.Models;

namespace CuddlyWombat.Controllers
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
            bool userLoggedIn = HttpContext.User.Identity.IsAuthenticated;
            if (userLoggedIn)
            {
                return View();
            }
            return Redirect("../Login");

        }

        public IActionResult Privacy()
        {
            bool userLoggedIn = HttpContext.User.Identity.IsAuthenticated;
            if (userLoggedIn)
            {
                return View();
            }
            return Redirect("../Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
