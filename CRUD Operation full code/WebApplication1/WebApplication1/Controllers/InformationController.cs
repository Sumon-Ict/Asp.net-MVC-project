using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Name"] = "Md Sumon Mia";
            ViewBag.message = "viewbag message section";


            return View();
        }
    }
}
