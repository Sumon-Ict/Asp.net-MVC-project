using Microsoft.AspNetCore.Mvc;
using MVCFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFirstDemo.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Summary()
        {
            //var model = new SummaryModel("sumon",1233);
            var model = new SummaryModel();  //defaut value displayed

            return View(model);

        }
    }
}
