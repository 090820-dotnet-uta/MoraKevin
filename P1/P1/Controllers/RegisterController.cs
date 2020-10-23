using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using P1;
using P1.Models;

namespace P1.Controllers
{
    public class RegisterController : Controller
    {
        private readonly P1Context _context;
        private UserAccount _account;
        private Customer _customer;
        private readonly IMemoryCache _cache;

        public RegisterController(IMemoryCache cache, P1Context context)
        {
            _context = context;
            _account = new UserAccount();
            _customer = new Customer();
            _cache = cache;
            /*DatabaseControl.SetContext(_context);*/

            if (!_cache.TryGetValue("account", out _account))
            {
                _cache.Set("account", new UserAccount());
            }
            if (!_cache.TryGetValue("customer", out _customer))
            {
                _cache.Set("customer", new Customer());
            }
        }

        public void SaveChanges()
        {
            _cache.Set("customer", _customer);
            _cache.Set("account", _account);
        }

        // GET: Register
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TryRegister(UserAccount account, string password2)
        {
            if (account.Username == null || account.Password == null)
            {
                return RedirectToAction("FieldEmpty");
            }
            else
            {
                if (DatabaseControl.AccountExists(account, _context))
                {
                    return RedirectToAction("UsernameTaken");
                }
                else if (account.Username.Length < 5)
                {
                    return RedirectToAction("UsernameTooShort");
                }
                else if (account.Password != password2)
                {
                    return RedirectToAction("PasswordsDifferent");
                }
                else if (account.Password.Length < 5)
                {
                    return RedirectToAction("PasswordTooShort");
                }
                else
                {
                    _account = account;
                    SaveChanges();
                    return RedirectToAction("CustomerInput");
                }
            }
        }

        public IActionResult CustomerInput()
        {
            return View();
        }

        public IActionResult TryLogin(Customer customer)
        {
            if (customer.FirstName == null)
            {
                return RedirectToAction("FirstNameShort");
            }
            else if (customer.LastName == null)
            {
                return RedirectToAction("LastNameShort");
            }
            else
            {
                _customer = customer;
                _account = (UserAccount)_cache.Get("account");
                DatabaseControl.RegisterAccount(_account, _customer, _context);
                Storage.SetCustomer(_customer);
                return View("../CustomerHome/Index", _customer);
            }
        }

        public IActionResult FieldEmpty()
        {
            ViewData["fieldEmpty"] = "Username or password cannot be empty. Please try again.";
            return View("Index");
        }

        public IActionResult FirstNameShort()
        {
            ViewData["firstNameShort"] = "First Name must be at least 1 character long. Please try again.";
            return View("CustomerInput");
        }

        public IActionResult LastNameShort()
        {
            ViewData["lastNameShort"] = "Last Name must be at least 1 character long. Please try again.";
            return View("CustomerInput");
        }

        public IActionResult PasswordsDifferent()
        {
            ViewData["usernameTaken"] = "Passwords do not match! Passwords must match.";
            return View("Index");
        }

        public IActionResult PasswordTooShort()
        {
            ViewData["passTooShort"] = "Password must be greater than 5 characters long! Try Again.";
            return View("Index");
        }

        public IActionResult UsernameTooShort()
        {
            ViewData["usernameTooShort"] = "Username must be greater than 5 characters long! Try Again.";
            return View("Index");
        }

        public IActionResult UsernameTaken()
        {
            ViewData["usernameTaken"] = "Username taken, please try a different username";
            return View("Index");
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(m => m.Username == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID");
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password,CustomerID")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", userAccount.CustomerID);
            return View(userAccount);
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", userAccount.CustomerID);
            return View(userAccount);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Password,CustomerID")] UserAccount userAccount)
        {
            if (id != userAccount.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountExists(userAccount.Username))
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
            ViewData["CustomerID"] = new SelectList(_context.Customers, "CustomerID", "CustomerID", userAccount.CustomerID);
            return View(userAccount);
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccount = await _context.UserAccounts
                .Include(u => u.Customer)
                .FirstOrDefaultAsync(m => m.Username == id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return View(userAccount);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userAccount = await _context.UserAccounts.FindAsync(id);
            _context.UserAccounts.Remove(userAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccountExists(string id)
        {
            return _context.UserAccounts.Any(e => e.Username == id);
        }
    }
}
