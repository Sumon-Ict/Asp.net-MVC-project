using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFirstDemo.Controllers
{
    public class BootstrapController : Controller
    {
        public IActionResult Layout1()
        {
            return View();
        }
        public IActionResult Layout2()
        {
            return View();

        }
        public IActionResult Layout3()
        {
            return View();

        }

    }
    
}
