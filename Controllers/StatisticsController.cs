using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuddlyWombat.Data;
using CuddlyWombat.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CuddlyWombat.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly CuddlyWombatContext _context;
        public StatisticsController (CuddlyWombatContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Acc")]

        public async Task<IActionResult> Index()
        {
            StatisticViewModel statisticViewModel = new StatisticViewModel();
            statisticViewModel.Items = await _context.Items.Where(i => i.Type != "GOA").Include(i => i.OrderItems).ToListAsync();
            statisticViewModel.Menus = await _context.Menus.Include(i => i.OrderMenus).ToListAsync();
            statisticViewModel.Orders = await _context.Orders
                .Where(i => i.IsPaid == true)
                .Include(i => i.OrderItems)
                .ThenInclude(i => i.Item)
                .Include(i => i.OrderMenus)
                .ThenInclude(i => i.Menu).ToListAsync();
            return View(statisticViewModel);
        }
    }
}