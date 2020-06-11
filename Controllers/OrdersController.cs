using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuddlyWombat.Data;
using CuddlyWombat.Models;
using Microsoft.AspNetCore.Authorization;
using CuddlyWombat.ViewModel;

namespace CuddlyWombat.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly CuddlyWombatContext _context;

        public OrdersController(CuddlyWombatContext context)
        {
            _context = context;
        }

        // GET: Orders
        [Authorize(Roles = "FOH,AR")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        [Authorize(Roles = "FOH,AR")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        [Authorize(Roles = "FOH,AR")]

        public async Task<IActionResult> Create(string orderID = null, string Name = null, string Description = null, string CustomerName = null)
        {

            if (orderID == null)
            {
                Order order = new Order()
                {
                    ID = Guid.NewGuid(),
                    Status = "Incomplete",
                    IsPaid = false,
                    DateCreated = DateTime.UtcNow,
                    Employee = User.Identity.Name,
                    AmountDue = 0,
                    OrderStartTime = DateTime.UtcNow
                };

                _context.Orders.Add(order);
                orderID = order.ID.ToString();
                await _context.SaveChangesAsync();
            }

            var orderViewModel = new OrderViewModel();
            orderViewModel.Items = await _context.Items.Where(i => i.Type != "GOA").ToListAsync();
            orderViewModel.Menus = await _context.Menus
                .Include(i => i.ItemMenus)
                .ToListAsync();
            orderViewModel.Order = _context.Orders.Where(i => i.ID.ToString() == orderID).First();
            orderViewModel.Order.OrderItems = await _context.OrderItems.Where(i => i.OrderID.ToString() == orderID).ToListAsync();
            orderViewModel.Order.OrderMenus = await _context.OrderMenus.Where(i => i.OrderID.ToString() == orderID).ToListAsync();
            if(Name != null)
            {
                orderViewModel.Order.Name = Name;
            }
            if(Description != null)
            {
                orderViewModel.Order.Description = Description;
            }
            if(CustomerName != null)
            {
                orderViewModel.Order.CustomerName = CustomerName;
            }


            return View("Create", orderViewModel);
        }
        [HttpPost]
        [Authorize(Roles = "FOH,AR")]
        public async Task<ActionResult<OrderViewModel>> SubtractOneFromAvailableList(string OrderID, string ID, string Type, string CustomerName,string Description, string Name)
        {

            /*Item updatedItem = _context.Items.Where(i => i.ID.ToString() == ID).First();
            var originalQantity = updatedItem.Quantity;

            updatedItem.Quantity -= 1;
            _context.Items.Update(updatedItem);
            await _context.SaveChangesAsync();*/

            var orderViewModel = new OrderViewModel
            {
                Items = await _context.Items.ToListAsync(),
                Menus = await _context.Menus
                .Include(i => i.ItemMenus)
                .ToListAsync(),
                Order = _context.Orders.Where(i => i.ID.ToString() == OrderID).First()
            };
            orderViewModel.Order.CustomerName = CustomerName;
            orderViewModel.Order.Description = Description;
            orderViewModel.Order.Name = Name;
            orderViewModel.Order.OrderItems = await _context.OrderItems.Where(i => i.OrderID.ToString() == OrderID).ToListAsync();
            orderViewModel.Order.OrderMenus = await _context.OrderMenus.Where(i => i.OrderID.ToString() == OrderID).ToListAsync();

            if (Type == "Item")
            {
                orderViewModel.Items.Where(i => i.ID.ToString() == ID).First().OrderItems = await _context.OrderItems.Where(i => i.ItemID.ToString() == ID).ToListAsync();
            }
            else if (Type == "Menu")
            {
                orderViewModel.Menus.Where(i => i.ID.ToString() == ID).First().OrderMenus = await _context.OrderMenus.Where(i => i.MenuID.ToString() == ID).ToListAsync();
            }

            
            UpdateOrderList(orderViewModel, ID, Type, "SubtractOneFromAvailableList");
            double amountDue = CalculateAmountDue(orderViewModel.Order);
            orderViewModel.Order.AmountDue = amountDue;
            await _context.SaveChangesAsync();
            return orderViewModel;



        }
        [HttpPost]
        [Authorize(Roles = "FOH,AR")]

        public async Task<ActionResult<OrderViewModel>> AddOneBackToAvailableList(string OrderID, string ID, string Type, string CustomerName, string Description, string Name)
        {
            var orderViewModel = new OrderViewModel
            {
                Items = await _context.Items.ToListAsync(),
                Menus = await _context.Menus
                .Include(i => i.ItemMenus)
                .ToListAsync(),
                Order = _context.Orders.Where(i => i.ID.ToString() == OrderID).First()
            };
            orderViewModel.Order.OrderItems = await _context.OrderItems.Where(i => i.OrderID.ToString() == OrderID).ToListAsync();
            orderViewModel.Order.OrderMenus = await _context.OrderMenus.Where(i => i.OrderID.ToString() == OrderID).ToListAsync();
            if (Type == "Item")
            {
                orderViewModel.Items.Where(i => i.ID.ToString() == ID).First().OrderItems = await _context.OrderItems.Where(i => i.ItemID.ToString() == ID).ToListAsync();
            }
            if (Type == "Menu")
            {
                orderViewModel.Menus.Where(i => i.ID.ToString() == ID).First().OrderMenus = await _context.OrderMenus.Where(i => i.MenuID.ToString() == ID).ToListAsync();
            }
            orderViewModel.Order.CustomerName = CustomerName;
            orderViewModel.Order.Description = Description;
            orderViewModel.Order.Name = Name;

            UpdateOrderList(orderViewModel, ID, Type, "AddOneBackToAvailableList");
            double amountDue = CalculateAmountDue(orderViewModel.Order);
            orderViewModel.Order.AmountDue = amountDue;
            await _context.SaveChangesAsync();
            return orderViewModel;

        }
        [HttpPost]
        [Authorize(Roles = "FOH,AR")]

        public async Task<ActionResult<string>> CompleteOrder(string OrderID ,string Status, string Name, string CustomerName, string OrderType, string Description )
        {
            var Order = _context.Orders.Where(i => i.ID.ToString() == OrderID).FirstOrDefault();
            Order.Status = Status;
            Order.CustomerName = CustomerName;
            Order.OrderType = OrderType;
            Order.Description = Description;
            Order.Name = Name;
             _context.Orders.Update(Order);
            await _context.SaveChangesAsync();
            if (OrderType == "Takeaway")
            {
                return "TakeNewOrder";
            }
            else if(OrderType == "Dinein")
            {
                return "GoToPayment";
            }
            else
            {
                return "SomethingHappened!";
            }
        }
        private double CalculateAmountDue(Order order)
        {
            double TotalAmount = 0;
            if (order.OrderItems != null)
            {
                foreach (OrderJItem oi in order.OrderItems)
                {
                    TotalAmount += oi.ItemsSold * oi.Item.Price;
                }
            }
            if (order.OrderMenus != null)
            {
                foreach (OrderJMenu om in order.OrderMenus)
                {
                    TotalAmount += om.MenusSold * om.Menu.Price;
                }
            }
           
            return TotalAmount;
        }
       
        private void UpdateOrderList(
            OrderViewModel orderViewModel,
            string ID,
            string type,
            string action)
        {
            if (action == "SubtractOneFromAvailableList")
            {
                if (type == "Item")
                {
               
                    orderViewModel.Items.Where(i => i.ID.ToString() == ID).First().Quantity -= 1;
                    var currentOrder = orderViewModel.Order;
                    OrderJItem orderItemLink;
                    if (orderViewModel.Order.OrderItems == null)
                    {
                        
                        var pendingItem = orderViewModel.Items.Where(i => i.ID.ToString() == ID).First();
                        orderViewModel.Order.OrderItems = new List<OrderJItem>();
                        orderItemLink = new OrderJItem
                        {
                            ID = Guid.NewGuid(),
                            ItemID = pendingItem.ID,
                            OrderID = currentOrder.ID,
                            ItemsSold = 1

                        };
                        orderViewModel.Order.OrderItems.Add(orderItemLink);
                        _context.OrderItems.Add(orderItemLink);

                    }
                    else if (orderViewModel.Order.OrderItems != null && 
                        orderViewModel.Order.OrderItems.Where(i => i.ItemID.ToString() == ID).Count() == 0)
                    {
                        var pendingItem = orderViewModel.Items.Where(i => i.ID.ToString() == ID).First();
                        orderItemLink = new OrderJItem
                        {
                            ID = Guid.NewGuid(),
                            ItemID = pendingItem.ID,
                            OrderID = currentOrder.ID,
                            ItemsSold = 1

                        };
                        orderViewModel.Order.OrderItems.Add(orderItemLink);
                        _context.OrderItems.Add(orderItemLink);
                    }
                    else
                    {
                        orderItemLink = orderViewModel.Order.OrderItems.Where(i => i.OrderID == currentOrder.ID && i.ItemID.ToString() == ID  ).First();
                        orderItemLink.ItemsSold += 1;
                        _context.OrderItems.Update(orderItemLink);
                    }
                    _context.Items.Update(orderViewModel.Items.Where(i => i.ID.ToString() == ID).First());
                }
                else if (type == "Menu")
                {
                    orderViewModel.Menus.Where(i => i.ID.ToString() == ID).First().Quantity -= 1;
                    var currentOrder = orderViewModel.Order;
                    OrderJMenu orderMenuLink;
                    
                    if (orderViewModel.Order.OrderMenus.Where(i => i.MenuID.ToString() == ID).Count() == 0)
                    {
                        Menu pendingMenu = orderViewModel.Menus.Where(i => i.ID.ToString() == ID).First();
                        orderMenuLink = new OrderJMenu
                        {
                            ID = Guid.NewGuid(),
                            MenuID = pendingMenu.ID,
                            OrderID = currentOrder.ID,
                            MenusSold = 1

                        };
                        orderViewModel.Order.OrderMenus.Add(orderMenuLink);
                        _context.OrderMenus.Add(orderMenuLink);
                    }
                    else
                    {
                        orderMenuLink = orderViewModel.Order.OrderMenus.Where(i => i.OrderID == currentOrder.ID && i.MenuID.ToString() == ID).First();
                        orderMenuLink.MenusSold += 1;
                        _context.OrderMenus.Update(orderMenuLink);
                    }
                    _context.Menus.Update(orderViewModel.Menus.Where(i => i.ID.ToString() == ID).First());
                }
            }
            else if (action == "AddOneBackToAvailableList")
            {
                if (type == "Item")
                {

                    orderViewModel.Items.Where(i => i.ID.ToString() == ID).First().Quantity += 1;
                    var currentOrder = orderViewModel.Order;
                    var orderItemLink = currentOrder.OrderItems.Where(i => i.OrderID == currentOrder.ID && i.ItemID.ToString() == ID).First();
                    if(orderItemLink.ItemsSold > 0)
                    {
                        orderItemLink.ItemsSold -= 1;
                        _context.OrderItems.Update(orderItemLink);
                    }
                    else
                    {
                        orderItemLink.ItemsSold = 0;
                        _context.OrderItems.Update(orderItemLink);
                    }
                    _context.Items.Update(orderViewModel.Items.Where(i => i.ID.ToString() == ID).First());
                }
                else if (type == "Menu")
                {

                    orderViewModel.Menus.Where(i => i.ID.ToString() == ID).First().Quantity += 1;
                    var currentOrder = orderViewModel.Order;
                    var orderMenuLink = currentOrder.OrderMenus.Where(i => i.OrderID == currentOrder.ID && i.MenuID.ToString() == ID).First();
                    if (orderMenuLink.MenusSold > 0)
                    {
                        orderMenuLink.MenusSold -= 1;
                        _context.OrderMenus.Update(orderMenuLink);
                    }
                    else
                    {
                        orderMenuLink.MenusSold = 0;
                        _context.OrderMenus.Update(orderMenuLink);
                    }
                    _context.Menus.Update(orderViewModel.Menus.Where(i => i.ID.ToString() == ID).First());
                }
            }
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FOH,AR")]

        public async Task<IActionResult> Create([Bind("AmountDue,Status,Employee,CustomerName,ID,Name,Description,DateCreated")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.ID = Guid.NewGuid();
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = "FOH,AR")]

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FOH,AR")]

        public async Task<IActionResult> Edit(Guid id, [Bind("AmountDue,Status,Employee,CustomerName,ID,Name,Description,DateCreated")] Order order)
        {
            if (id != order.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        [Authorize(Roles = "FOH,AR")]

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "FOH,AR")]

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(Guid id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }
    }
}
