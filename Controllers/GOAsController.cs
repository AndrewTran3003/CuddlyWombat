using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CuddlyWombat.Data;
using CuddlyWombat.Models;
using CuddlyWombat.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CuddlyWombat.Controllers
{
    public class GOAsController : Controller
    {
        private readonly CuddlyWombatContext _context;

        public GOAsController(CuddlyWombatContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        [Authorize(Roles = "FOH,AR")]
        public async Task<IActionResult> Index(string orderID = null)
        {
            var currentTime = DateTime.UtcNow;
            GOAViewModel goaViewModel = new GOAViewModel();
            var orders = await _context.Orders.Where(i => i.IsPaid == true && i.Status == "Complete").ToListAsync();
            List<Order> overdueOrders = new List<Order>();
            double timeInterval = 1;

            foreach (Order order in orders)
            {

                if (currentTime.Subtract(order.OrderStartTime).TotalMinutes > timeInterval)
                {
                    overdueOrders.Add(order);

                }
            }
            goaViewModel.LateOrders = overdueOrders;
            goaViewModel.GOAItems = await _context.Items.Where(i => i.Type == "GOA").ToListAsync();
            if (orderID != null)
            {
                Order activeLateOrder = new Order();
                activeLateOrder = _context.Orders.Where(i => i.ID.ToString() == orderID)
                    .Include(i => i.OrderItems)
                    .ThenInclude(i => i.Item)
                    .Include(i => i.OrderMenus)
                    .ThenInclude(i => i.Menu)
                    .First();
                goaViewModel.ActiveLateOrder = activeLateOrder;
            }
            return View(goaViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "FOH,AR")]
        public async Task<ActionResult<string>> HandleAction(string OrderID, string ItemID)
        {

            Order currentLateOrder = _context.Orders
                .Where(i => i.ID.ToString() == OrderID)
                .Include(i => i.OrderItems)
                .First();
            Item currentGOAItem = _context.Items.Where(i => i.ID.ToString() == ItemID).First();
            OrderJItem currentOrderGOA = new OrderJItem
            {
                ID = Guid.NewGuid(),
                OrderID = currentLateOrder.ID,
                ItemID = currentGOAItem.ID,
                Order = currentLateOrder,
                Item = currentGOAItem,
                ItemsSold = 1
            };
            currentLateOrder.OrderItems.Add(currentOrderGOA);
            currentGOAItem.Quantity -= 1;
            currentLateOrder.Status = "GOAReceived";
            _context.Orders.Update(currentLateOrder);
            _context.Items.Update(currentGOAItem);
            _context.OrderItems.Add(currentOrderGOA);
            await _context.SaveChangesAsync();
            string response = "Success";
            return response;


        }
        [Authorize]
        public async Task<ActionResult<string>> AnyOverdueOrder()
        {
            string result;
            var currentTime = DateTime.UtcNow;
            var orders = await _context.Orders.Where(i => i.IsPaid == true && (i.Status == "Complete")).ToListAsync();
            List<string> overdueOrderIDs = new List<string>();
            double timeInterval = 15;
   
            foreach (Order order in orders)
            {
                
                if (currentTime.Subtract(order.OrderStartTime).TotalMinutes > timeInterval)
                {
                    overdueOrderIDs.Add(order.ID.ToString());
                  
                }
            }
            if (overdueOrderIDs.Count() == 1)
            {
                result = "OneOverdue";
            }
            else if (overdueOrderIDs.Count() > 1)
            {
                result = "MultipleOverdue";
            }
            else
            {
                result = "Ok";
            }
            
            await _context.SaveChangesAsync();
            return result;

        }
    }
}
