using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using P1;
using P1.Models;

namespace P1.Controllers
{
    public class LocationsController : Controller
    {
        private readonly P1Context _context;
        private Location _currentLocation;

        public LocationsController(P1Context context)
        {
            _context = context;
            _currentLocation = new Location();
            /*DatabaseControl.SetContext(_context);*/
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locations.ToListAsync());
        }

        public IActionResult GetLocation(int ID)
        {
            _currentLocation = DatabaseControl.GetLocation(ID, _context);
            Storage.SetLocation(_currentLocation);
/*            if(Storage.GetProductToBuy() != null)
            {
                List<ProductInStock> shoppingCart = new List<ProductInStock>();
                shoppingCart.Add(Storage.GetProductToBuy());
                Storage.SetShoppingCart(shoppingCart);
            }*/
            return View(_currentLocation);
        }

        public IActionResult EditQuantity(int ID)
        {
            ProductInStock p = Storage.GetFromCart(ID);
            Storage.SetProductEditing(p);
            return View(p);
        }

        public IActionResult SaveQuantity(int quantity)
        {
            Storage.ChangeQuantity(quantity);
            return RedirectToAction("ShoppingCart");
        }

        public IActionResult ShoppingCart()
        {
            /*if (Request.Form["Update"] != "")
            { }*/
            if (Storage.GetShoppingCart().Count == 0)
            {
                return View("EmptyCart");
            }
            else
            {
                return View(Storage.GetShoppingCart());
            }
        }

        public IActionResult Checkout()
        {
            if (Storage.GetShoppingCart().Count == 0)
            {
                return View("EmptyCart");
            }
            else
            {
                List<Billing> cardsOnFile = DatabaseControl.GetCardsOnFileForCustomer(Storage.GetCustomer(), _context);
                return View("../Billing/BillingOptions", cardsOnFile);
            }
        }

        public IActionResult Return()
        {
            _currentLocation = Storage.GetLocation();
            return View("GetLocation", _currentLocation);
        }

        public IActionResult Exit()
        {
            Customer _customer = Storage.GetCustomer();
            Storage.Clean();
            return View("../CustomerHome/Index", _customer);
        }


        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }


        public IActionResult GetAddToCart(int ID)
        {
            Location _currentLocation = DatabaseControl.GetLocation(ID, _context);
            Storage.SetLocation(_currentLocation);
            ProductInStock productInStock = DatabaseControl.GetProductInStock(Storage.GetProduct().ProductID, _currentLocation, _context);
            Storage.SetProductToBuy(productInStock);
            return View("AddToCart", productInStock); 
        }

        public IActionResult AddToCart(int id)
        {
            _currentLocation = Storage.GetLocation();
            ProductInStock productInStock = DatabaseControl.GetProductInStock(id, _currentLocation, _context);
            if (Storage.ShoppingCartHas(productInStock))
            {
                return View("ProductAlreadyInCart", productInStock);
            }
            else
            {
                Storage.SetProductToBuy(productInStock);
                return View(productInStock);
            }
        }

        public IActionResult PlaceInCart(int quantity)
        {
            int id = Storage.GetProductToBuy().ProductID;
            _currentLocation = Storage.GetLocation();
            ProductInStock productInStock = DatabaseControl.GetProductInStock(id, _currentLocation, _context);
            if (quantity < 1 || quantity > productInStock.Max)
            {
                return View("GetLocation", _currentLocation);
            }
            else
            {
                productInStock.Quantity = quantity;
                _currentLocation = Storage.GetLocation();
                List<ProductInStock> shoppingCart = Storage.GetShoppingCart();
                shoppingCart.Add(productInStock);
                Storage.SetShoppingCart(shoppingCart);
                ViewData["itemAdded"] = productInStock.Name + " has been added to your shopping cart!";
                return View("GetLocation", _currentLocation);
            }
        }

        public IActionResult RemoveItem(int ID)
        {
            Storage.DeleteProductInCart(ID);
            return RedirectToAction("ShoppingCart");
        }

        public IActionResult GetGuitarsFrom()
        {
            _currentLocation = Storage.GetLocation();
            List<Product> guitars = DatabaseControl.FindProductsOfTypeFromStore("GUITAR", _currentLocation, _context);
            List<ProductInStock> guitarsInStock = DatabaseControl.GetProductsInStockAtLocation(guitars, _currentLocation, _context);
            return View(guitarsInStock);
        }

        public IActionResult GetBassFrom()
        {
            _currentLocation = Storage.GetLocation();
            List<Product> bass = DatabaseControl.FindProductsOfTypeFromStore("BASS", _currentLocation, _context);
            List<ProductInStock> bassInStock = DatabaseControl.GetProductsInStockAtLocation(bass, _currentLocation, _context);
            return View(bassInStock);
        }

        public IActionResult GetPianosFrom()
        {
            _currentLocation = Storage.GetLocation();
            List<Product> pianos = DatabaseControl.FindProductsOfTypeFromStore("PIANO", _currentLocation, _context);
            List<ProductInStock> pianosInStock = DatabaseControl.GetProductsInStockAtLocation(pianos, _currentLocation, _context);
            return View(pianosInStock);
        }

        public IActionResult GetDrumsFrom()
        {
            _currentLocation = Storage.GetLocation();
            List<Product> drums = DatabaseControl.FindProductsOfTypeFromStore("DRUMS", _currentLocation, _context);
            List<ProductInStock> drumsInStock = DatabaseControl.GetProductsInStockAtLocation(drums, _currentLocation, _context);
            return View(drumsInStock);
        }

        public IActionResult GetMicsFrom()
        {
            _currentLocation = Storage.GetLocation();
            List<Product> mics = DatabaseControl.FindProductsOfTypeFromStore("MIC", _currentLocation, _context);
            List<ProductInStock> micsInStock = DatabaseControl.GetProductsInStockAtLocation(mics, _currentLocation, _context);
            return View(micsInStock);
        }

        public IActionResult GetAccessoriesFrom()
        {
            _currentLocation = Storage.GetLocation();
            List<Product> accs = DatabaseControl.FindProductsOfTypeFromStore("ACC", _currentLocation, _context);
            List<ProductInStock> accsInStock = DatabaseControl.GetProductsInStockAtLocation(accs, _currentLocation, _context);
            return View(accsInStock);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationID,Name,AddressNum,AddressStreet,AddressCity,AddressState,AddressZipCode,Description")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationID,Name,AddressNum,AddressStreet,AddressCity,AddressState,AddressZipCode,Description")] Location location)
        {
            if (id != location.LocationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationExists(location.LocationID))
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
            return View(location);
        }

        // GET: Locations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var location = await _context.Locations
                .FirstOrDefaultAsync(m => m.LocationID == id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationExists(int id)
        {
            return _context.Locations.Any(e => e.LocationID == id);
        }
    }
}
