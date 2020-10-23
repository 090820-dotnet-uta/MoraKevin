using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCDockerDemo.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index(string input)
        {
            if (input == "something below.")
            {
                return View("Correct");
            }
            else
            {
                return View("Incorrect");
            }
        }

        public IActionResult Correct(string input)
        {
            return View();
        }

        public IActionResult Incorrect(string input)
        {
            return View();
        }
    }
}
