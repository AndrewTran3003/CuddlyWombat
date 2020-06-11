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
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "FOH,AR")]

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
        [Authorize(Roles = "FOH,AR")]

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

                Payment newPayment = new Payment
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
                    PaymentID = newPayment.ID,
                    Order = paymentViewModel.ActiveOrder.Order,
                    Payment = newPayment
                };
                newPayment.PaymentOrder = paymentOrder;
                paymentViewModel.ActiveOrder.Order.PaymentOrder = paymentOrder;
                var newReceipt = new Receipt
                {
                    ID = Guid.NewGuid(),
                    Name = "Receipt for " + newPayment.CustomerName,
                    Description = newPayment.Description,
                    DateCreated = DateTime.UtcNow,
                    CustomerName = newPayment.CustomerName,
                    EmployeeName = newPayment.EmployeeName,
                    CardNumber = "4916239779719037",
                    MerchantID = "654asd-fdacd2-566ddc-5dv2z5",
                    Total = newPayment.Amount
                };
                var orderItem = _context.OrderItems.Where(i => i.OrderID == paymentViewModel.ActiveOrder.Order.ID);
                var orderMenu = _context.OrderMenus.Where(i => i.OrderID == paymentViewModel.ActiveOrder.Order.ID);
                var items = await _context.Items.ToListAsync();
                var menus = await _context.Menus.ToListAsync();
                var itemToAdd = new List<Item>();
                string orderDetail = "";

                foreach (OrderJItem oj in orderItem)
                {
                    foreach (Item item in items)
                    {
                        if (item.ID == oj.ItemID)
                        {
                            var amountDue = oj.ItemsSold * item.Price;
                            orderDetail = orderDetail + item.Name + ":" + oj.ItemsSold + ":" + amountDue + ",";
                        }
                    }
                }
                foreach (OrderJMenu om in orderMenu)
                {
                    foreach (Menu menu in menus)
                    {
                        if (menu.ID == om.MenuID)
                        {
                            var amountDue = om.MenusSold * menu.Price;
                            orderDetail = orderDetail + menu.Name + ":" + om.MenusSold + ":" + amountDue + ",";
                        }
                    }
                }

                var newPaymentReceipt = new PaymentJReceipt
                {
                    ID = Guid.NewGuid(),
                    PaymentID = newPayment.ID,
                    ReceiptID = newReceipt.ID,
                    Payment = newPayment,
                    Receipt = newReceipt

                };

                newReceipt.OrderDetail = orderDetail;
                newReceipt.PaymentReceipt = newPaymentReceipt;
                _context.Receipts.Add(newReceipt);
                _context.PaymentReceipt.Add(newPaymentReceipt);
                _context.Payment.Add(newPayment);
                _context.PaymentOrder.Add(paymentOrder);
                _context.Orders.Update(paymentViewModel.ActiveOrder.Order);
                await _context.SaveChangesAsync();
                response = "Paid";
            }
            return response;
        }
    }
}
