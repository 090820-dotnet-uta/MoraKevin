using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P1;
using P1.Models;

namespace P1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly P1Context _context;

        public OrdersController(P1Context context)
        {
            _context = context;
            /*DatabaseControl.SetContext(_context);*/
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var p1Context = _context.Orders.Include(o => o.Billing).Include(o => o.Customer).Include(o => o.Location).Include(o => o.Shipping);
            return View(await p1Context.ToListAsync());
        }

        public IActionResult ConfirmOrder()
        {
            DatabaseControl.PlaceOrder(Storage.GetShoppingCart(), Storage.GetCardUsing(), Storage.WhatsTheAddy(), Storage.GetCustomer(), Storage.GetLocation(), _context);
            ViewData["orderPlaced"] = "Your order has been placed! Click View Order to view your past orders.";
            Storage.CleanAfterOrder();
            return View("../Locations/GetLocation", Storage.GetLocation());
        }

        public IActionResult GetOrders()
        {
            List<Order> orders = DatabaseControl.GetOrdersInfoFromLocation(Storage.GetLocation(), _context);
            return View("PastOrdersHere", orders);
        }

        public IActionResult GetPastOrders()
        {
            List<Order> orders = DatabaseControl.GetPastOrdersFromCustomer(Storage.GetCustomer(), _context);
            if (orders.Count == 0)
            {
                return View("NoOrdersPlaced");
            }
            else
            {
                return View("PastOrders", orders);
            }
        }

        public IActionResult GetPastOrderDetails(int ID)
        {
            Order o = DatabaseControl.GetOrder(ID, false, _context);
            return View("PastOrderDetails", o);
        }

        public IActionResult GetPastOrderDetailsHere(int ID)
        {

            Order o = DatabaseControl.GetOrder(ID, true, _context);
            return View("PastOrderDetailsHere", o);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Billing)
                .Include(o => o.Customer)
                .Include(o => o.Location)
                .Include(o => o.Shipping)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["BillingID"] = new SelectList(_context.BillingInformation, "BillingID", "AddressCity");
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID");
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID");
            ViewData["ShippingID"] = new SelectList(_context.ShippingInformation, "ShippingID", "AddressCity");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,CustomerID,LocationID,OrderTime,BillingID,ShippingID")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BillingID"] = new SelectList(_context.BillingInformation, "BillingID", "AddressCity", order.BillingID);
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", order.CustomerID);
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", order.LocationID);
            ViewData["ShippingID"] = new SelectList(_context.ShippingInformation, "ShippingID", "AddressCity", order.ShippingID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["BillingID"] = new SelectList(_context.BillingInformation, "BillingID", "AddressCity", order.BillingID);
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", order.CustomerID);
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", order.LocationID);
            ViewData["ShippingID"] = new SelectList(_context.ShippingInformation, "ShippingID", "AddressCity", order.ShippingID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,CustomerID,LocationID,OrderTime,BillingID,ShippingID")] Order order)
        {
            if (id != order.OrderID)
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
                    if (!OrderExists(order.OrderID))
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
            ViewData["BillingID"] = new SelectList(_context.BillingInformation, "BillingID", "AddressCity", order.BillingID);
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", order.CustomerID);
            ViewData["LocationID"] = new SelectList(_context.Locations, "LocationID", "LocationID", order.LocationID);
            ViewData["ShippingID"] = new SelectList(_context.ShippingInformation, "ShippingID", "AddressCity", order.ShippingID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Billing)
                .Include(o => o.Customer)
                .Include(o => o.Location)
                .Include(o => o.Shipping)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
