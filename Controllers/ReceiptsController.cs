using System;
using System.Collections.Generic;
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
    public class ReceiptsController : Controller
    {
        private readonly CuddlyWombatContext _context;
        public ReceiptsController(CuddlyWombatContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index(string orderID = null)
        {
            ReceiptViewModel receiptViewModel = new ReceiptViewModel();



            if (orderID != null)
            {
                Payment currentPayment = _context.Payment.Where(i => i.PaymentOrder.OrderID.ToString() == orderID).First();
                PaymentJReceipt paymentReceipt = _context.PaymentReceipt.Where(i => i.PaymentID == currentPayment.ID).FirstOrDefault();

                if (paymentReceipt == null)
                {

                    Order currentOrder = _context.Orders.Where(i => i.ID.ToString() == orderID).First();
                    var newReceipt = new Receipt
                    {
                        ID = Guid.NewGuid(),
                        Name = "Receipt for " + currentPayment.CustomerName,
                        Description = currentPayment.Description,
                        DateCreated = DateTime.UtcNow,
                        CustomerName = currentPayment.CustomerName,
                        EmployeeName = currentPayment.EmployeeName,
                        CardNumber = "4916239779719037",
                        MerchantID = "654asd-fdacd2-566ddc-5dv2z5",
                        Total = currentPayment.Amount
                    };
                    var orderItem = _context.OrderItems.Where(i => i.OrderID == currentOrder.ID);
                    var orderMenu = _context.OrderMenus.Where(i => i.OrderID == currentOrder.ID);
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
                        PaymentID = currentPayment.ID,
                        ReceiptID = newReceipt.ID,
                        Payment = currentPayment,
                        Receipt = newReceipt

                    };

                    newReceipt.OrderDetail = orderDetail;
                    newReceipt.PaymentReceipt = newPaymentReceipt;
                    receiptViewModel.CurrentReceipt = newReceipt;
                    _context.Receipts.Add(newReceipt);
                    _context.PaymentReceipt.Add(newPaymentReceipt);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    Receipt currentReceipt = _context.Receipts.Where(i => i.PaymentReceipt.PaymentID == currentPayment.ID).First();
                    receiptViewModel.CurrentReceipt = currentReceipt;
                }
                receiptViewModel.ActiveOrderID = orderID;
            }
            receiptViewModel.Receipts = await _context.Receipts
                            .Include(i => i.PaymentReceipt)
                            .ThenInclude(i => i.Payment)
                            .ThenInclude(i => i.PaymentOrder)
                            .ThenInclude(i => i.Order)
                            .ToListAsync();

            return View(receiptViewModel);
        }
    }
}
