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
    public class ShippingController : Controller
    {
        private readonly P1Context _context;

        public ShippingController(P1Context context)
        {
            _context = context;
            /*DatabaseControl.SetContext(_context);*/
        }

        // GET: Shipping
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShippingInformation.ToListAsync());
        }

        // GET: Shipping/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = await _context.ShippingInformation
                .FirstOrDefaultAsync(m => m.ShippingID == id);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // GET: Shipping/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shipping/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ShippingID,AddressNum,AddressStreet,AddressCity,AddressState,AddressZipCode")] Shipping shipping, string num, string zip)
        {
            if (int.TryParse(zip, out int z) && zip.Length == 5 &&
                int.TryParse(num, out int n) && num.Length > 0)
            {
                shipping.AddressNum = int.Parse(num);
                shipping.AddressZipCode = zip;
                DatabaseControl.AddNewShippingInformationToUser(shipping, Storage.GetCustomer(), _context);
                List<Shipping> shippingOptions = DatabaseControl.GetShippingAddresssesOnFileForCustomer(Storage.GetCustomer(), _context);
                return View("ShippingOptions", shippingOptions);
            }
            else
            {
                ViewData["invalidAddress"] = "One or more input parameters were invalid. Please try again.";
                return View("Create");
            }
        }

        public IActionResult ChooseAddress(int ID)
        {
            Storage.SetAddy(DatabaseControl.GetAddress(ID, _context));
            Storage.SetOrderDetails();
            Order orderDetails = Storage.GetOrder();
            return View("../Orders/OrderDetails", orderDetails);
        }

        // GET: Shipping/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = await _context.ShippingInformation.FindAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }
            return View(shipping);
        }

        // POST: Shipping/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShippingID,AddressNum,AddressStreet,AddressCity,AddressState,AddressZipCode")] Shipping shipping)
        {
            if (id != shipping.ShippingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingExists(shipping.ShippingID))
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
            return View(shipping);
        }

        // GET: Shipping/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipping = await _context.ShippingInformation
                .FirstOrDefaultAsync(m => m.ShippingID == id);
            if (shipping == null)
            {
                return NotFound();
            }

            return View(shipping);
        }

        // POST: Shipping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipping = await _context.ShippingInformation.FindAsync(id);
            _context.ShippingInformation.Remove(shipping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippingExists(int id)
        {
            return _context.ShippingInformation.Any(e => e.ShippingID == id);
        }
    }
}
