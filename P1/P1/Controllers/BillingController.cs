using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P1;
using P1.Models;

namespace P1.Controllers
{
    public class BillingController : Controller
    {
        private readonly P1Context _context;

        public BillingController(P1Context context)
        {
            _context = context;
            /*DatabaseControl.SetContext(_context);*/
        }

        // GET: Billing
        public async Task<IActionResult> Index()
        {
            return View(await _context.BillingInformation.ToListAsync());
        }

        // GET: Billing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.BillingInformation
                .FirstOrDefaultAsync(m => m.BillingID == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // GET: Billing/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Billing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BillingID,NameOnCard,CardNumber,SecurityCode,AddressNum,AddressStreet,AddressCity,AddressState,AddressZipCode")] Billing billing, string yearMonth, string num, string zip, string security)
        {
            if (yearMonth != null && billing.CardNumber.Length == 16 && 
                int.TryParse(billing.CardNumber.Substring(0, 7), out int cn1) &&
                int.TryParse(billing.CardNumber.Substring(8), out int cn2) && security.Length == 3 && 
                int.TryParse(security, out int s) && int.TryParse(zip, out int z) && zip.Length == 5 &&
                int.TryParse(num, out int n) && num.Length > 0)
            {
                billing.AddressNum = int.Parse(num);
                billing.ExpirationYear = int.Parse(yearMonth.Substring(0, 4));
                billing.ExpirationMonth = int.Parse(yearMonth.Substring(5));
                billing.SecurityCode = int.Parse(security);
                billing.AddressZipCode = zip;
                DatabaseControl.AddNewCardInformationToUser(billing, Storage.GetCustomer(), _context);
                DatabaseControl.AddNewShippingInformationToUser(billing, Storage.GetCustomer(), _context);
                List<Billing> cardsOnFile = DatabaseControl.GetCardsOnFileForCustomer(Storage.GetCustomer(), _context);
                return View("BillingOptions", cardsOnFile);
            }
            else
            {
                ViewData["invalidCard"] = "One or more input parameters were invalid. Please try again.";
                return View("Create");
            }
        }



        public IActionResult UseCard(int ID)
        {
            Billing card = DatabaseControl.GetCard(ID, _context);
            Storage.SetCardUsing(card);
            List<Shipping> addresses = DatabaseControl.GetShippingAddresssesOnFileForCustomer(Storage.GetCustomer(), _context);
            return View("../Shipping/ShippingOptions", addresses);
        }

        // GET: Billing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.BillingInformation.FindAsync(id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        // POST: Billing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BillingID,NameOnCard,CardNumber,ExpirationMonth,ExpirationYear,SecurityCode,AddressNum,AddressStreet,AddressCity,AddressState,AddressZipCode")] Billing billing)
        {
            if (id != billing.BillingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillingExists(billing.BillingID))
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
            return View(billing);
        }

        // GET: Billing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billing = await _context.BillingInformation
                .FirstOrDefaultAsync(m => m.BillingID == id);
            if (billing == null)
            {
                return NotFound();
            }

            return View(billing);
        }

        // POST: Billing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billing = await _context.BillingInformation.FindAsync(id);
            _context.BillingInformation.Remove(billing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillingExists(int id)
        {
            return _context.BillingInformation.Any(e => e.BillingID == id);
        }
    }
}
