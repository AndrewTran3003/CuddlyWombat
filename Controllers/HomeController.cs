using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CuddlyWombat.Models;
using CuddlyWombat.ViewModel;
using CuddlyWombat.Data;
using Microsoft.EntityFrameworkCore;

namespace CuddlyWombat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CuddlyWombatContext _context;

        public HomeController(ILogger<HomeController> logger,CuddlyWombatContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.Items = await _context.Items.Where(i => i.Type != "GOA").ToListAsync();
            homeViewModel.Menus = await _context.Menus.Include(i => i.ItemMenus).ToListAsync();
            return View(homeViewModel);


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
