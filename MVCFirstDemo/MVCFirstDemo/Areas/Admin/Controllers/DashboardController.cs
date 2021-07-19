using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFirstDemo.Areas.Admin.Controllers
{
   [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Information()
        {
            ViewData["Name"] = "My name is sumon ";

            ViewBag.Age = "I am 23 years old";
            return View();

        }
      public IActionResult Test()
        {
           
            return View();

        }
    }
}
