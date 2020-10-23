using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using P1;
using P1.DAOs;
using P1.Models;

namespace P1.Controllers
{
    public class LoginController : Controller
    {
        private readonly P1Context _context;
        private readonly ILogger<HomeController> _logger;
        private IMemoryCache _cache;
        private UserAccount _account;
        private Customer _customer;

        public LoginController(P1Context context)
        {
            _context = context;
            _account = new UserAccount();
            _customer = new Customer();
            /*DatabaseControl.SetContext(_context);*/
        }

        // GET: Login/Details/5
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

        // GET: Login
        public IActionResult Index()
        {
            return View();
        }

        // GET: Login/Failed
        public IActionResult LoginFailed()
        {
            ViewData["loginFailed"] = "Username or Password was incorrect, please try again";
            return View("Index");
        }

        [ValidateAntiForgeryToken]
        public IActionResult TryLogin(UserAccount account)
        {
            if (DatabaseControl.LoginSuccesful(account, _context)) 
            {
                _account = account;
                _customer = DatabaseControl.GetCurrentCustomer(_account, _context);
                Storage.SetCustomer(_customer);
                return View("../CustomerHome/Index", _customer);
            }
            else
            {
                return RedirectToAction("LoginFailed");
            }
        }
    }
}
