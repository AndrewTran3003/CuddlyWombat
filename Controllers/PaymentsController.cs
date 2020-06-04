using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CuddlyWombat.Data;
using CuddlyWombat.Models;
using CuddlyWombat.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CuddlyWombat.Controllers
{
    public class PaymentsController : Controller
    {
        // GET: /<controller>/
        private readonly CuddlyWombatContext _context;
        public PaymentsController(CuddlyWombatContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string orderID = null)
        {
            PaymentViewModel paymentViewModel = new PaymentViewModel
            {
                Orders = await _context.Orders.Where(i => i.Status == "Pending" && i.IsPaid == false).ToListAsync()
            };

            if (orderID != null)
            {
                paymentViewModel.ActiveOrder = new OrderViewModel();
                paymentViewModel.ActiveOrder.Order = paymentViewModel.Orders.Where(i => i.ID.ToString() == orderID).First();
                paymentViewModel.ActiveOrder.Items = await _context.Items.ToListAsync();
                paymentViewModel.ActiveOrder.Menus = await _context.Menus.ToListAsync();
                foreach (Menu menu in paymentViewModel.ActiveOrder.Menus)
                {
                    menu.OrderMenus = await _context.OrderMenus.Where(i => i.OrderID.ToString() == orderID && i.MenuID == menu.ID).ToListAsync();
                }

                foreach (Item item in paymentViewModel.ActiveOrder.Items)
                {
                    item.OrderItems = await _context.OrderItems.Where(i => i.OrderID.ToString() == orderID && i.ItemID == item.ID).ToListAsync();
                }

                /*var orderWithID = paymentViewModel.Orders.Where(i => i.ID.ToString() == orderID).First();
                orderWithID.OrderItems = await _context.OrderItems.Where(i => i.OrderID.ToString() == orderID).ToListAsync();
                orderWithID.OrderMenus = await _context.OrderMenus.Where(i => i.OrderID.ToString() == orderID).ToListAsync();

                foreach (OrderJMenu orderMenu in orderWithID.OrderMenus) {
                    paymentViewModel.Menus.Append(orderMenu.Menu);
                }

                foreach (OrderJItem orderItem in orderWithID.OrderItems)
                {

                }*/


            }

            return View(paymentViewModel);
        }
        [HttpPost]
        public async Task<ActionResult<string>> HandleAction(string orderID, string action)
        {
            string response = "default";
            PaymentViewModel paymentViewModel = new PaymentViewModel();
            paymentViewModel.ActiveOrder = new OrderViewModel();
            paymentViewModel.ActiveOrder.Order = _context.Orders.Where(i => i.ID.ToString() == orderID).First();
            if (action == "Edit")
            {
                response = "Edit";
            }
            else if (action == "Delete")
            {

                paymentViewModel.ActiveOrder.Order.Status = "Cancelled";
                _context.Orders.Update(paymentViewModel.ActiveOrder.Order);
                await _context.SaveChangesAsync();
                response = "Deleted";

            }
            else if (action == "Pay") {
                paymentViewModel.ActiveOrder.Order.IsPaid = true;
                paymentViewModel.ActiveOrder.Order.Status = "Complete";
                paymentViewModel.ActiveOrder.Order.OrderStartTime = DateTime.UtcNow;

                Payment payment = new Payment
                {
                    ID = Guid.NewGuid(),
                    Name = paymentViewModel.ActiveOrder.Order.Name,
                    Description = paymentViewModel.ActiveOrder.Order.Description,
                    DateCreated = DateTime.UtcNow,
                    Method = "Card",
                    EmployeeName = paymentViewModel.ActiveOrder.Order.Employee,
                    CustomerName = paymentViewModel.ActiveOrder.Order.CustomerName,
                    Amount = paymentViewModel.ActiveOrder.Order.AmountDue
                };
                PaymentJOrder paymentOrder = new PaymentJOrder
                {
                    ID = Guid.NewGuid(),
                    OrderID = Guid.Parse(orderID),
                    PaymentID = payment.ID,
                    Order = paymentViewModel.ActiveOrder.Order,
                    Payment = payment
                };
                payment.PaymentOrder = paymentOrder;
                paymentViewModel.ActiveOrder.Order.PaymentOrder = paymentOrder;

                _context.Payment.Add(payment);
                _context.PaymentOrder.Add(paymentOrder);
                _context.Orders.Update(paymentViewModel.ActiveOrder.Order);
                await _context.SaveChangesAsync();
                response = "Paid";
            }
            return response;
        }
    }
}
