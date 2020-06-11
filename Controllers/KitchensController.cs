using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuddlyWombat.Data;
using CuddlyWombat.Models;
using CuddlyWombat.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CuddlyWombat.Controllers
{
    public class KitchensController : Controller
    {
        private readonly CuddlyWombatContext _context;
        public KitchensController(CuddlyWombatContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "BOH,AR")]
        public async Task<IActionResult> Index()
        {
            KitchenViewModel kitchenViewModel = new KitchenViewModel();
            kitchenViewModel.OrdersToBeFinished = await _context.Orders
                .Where(i => i.IsPaid == true && (i.Status == "Complete" || i.Status == "GOAReceived"))
                .Include(i => i.OrderItems)
                .ThenInclude(i => i.Item)
                .Include(i => i.OrderMenus)
                .ThenInclude(i => i.Menu)
                .ToListAsync();

            return View(kitchenViewModel);
        }
        [HttpPost]
        [Authorize(Roles = "BOH,AR")]
        public async Task<ActionResult<string>> FinishOrder (string OrderID)
        {
            string response;
            Order order = new Order();
            order = _context.Orders.Where(i => i.ID.ToString() == OrderID).FirstOrDefault();
            order.Status = "Delivered";
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            response = "Ok";
            return response;
        }
    }
}