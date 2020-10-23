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
    public class ProductsController : Controller
    {
        private readonly P1Context _context;

        public ProductsController(P1Context context)
        {
            _context = context;
            /*DatabaseControl.SetContext(_context);*/
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        public IActionResult GetGuitars()
        {
            List<Product> guitars = DatabaseControl.GetAllProductsOfType("GUITAR", _context);
            return View(guitars);
        }

        public IActionResult GetBass()
        {
            List<Product> bass = DatabaseControl.GetAllProductsOfType("BASS", _context);
            return View(bass);
        }

        public IActionResult GetPianos()
        {
            List<Product> pianos = DatabaseControl.GetAllProductsOfType("PIANO", _context);
            return View(pianos);
        }

        public IActionResult GetDrums()
        {
            List<Product> pianos = DatabaseControl.GetAllProductsOfType("DRUMS", _context);
            return View(pianos);
        }

        public IActionResult GetMics()
        {
            List<Product> mics = DatabaseControl.GetAllProductsOfType("MIC", _context);
            return View(mics);
        }

        public IActionResult GetAccessories()
        {
            List<Product> accs = DatabaseControl.GetAllProductsOfType("ACC", _context);
            return View(accs);
        }

        public IActionResult FindLocationsWithProduct(int id)
        {
            List<Location> storeOptions = DatabaseControl.FindLocationsWithProduct(id, _context);
            Product ProductToBuy = DatabaseControl.GetProduct(id, _context);
            Storage.SetProduct(ProductToBuy);
            ViewData["productName"] = ProductToBuy.Name;
            return View("StoreOptions", storeOptions);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,Price,Type,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Price,Type,Description")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
