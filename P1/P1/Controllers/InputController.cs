using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P1;

namespace P1.Controllers
{
    public class InputController : Controller
    {
        private P1Context _context;

        public InputController(P1Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyUsername(string username)
        {
            if (!DatabaseControl.AccountExists(username, _context))
            {
                return Json($"Username {username} is already in use.");
            }
            return Json(true);
        }
    }
}
