using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class DashboardController : Controller
    {
        private IDatabaseService _databaseservice;
        public DashboardController(IDatabaseService databaseservice)
        {
            _databaseservice = databaseservice;
        }
        public IActionResult Summary()
        {

            var Name = _databaseservice.Getname();

            var model = new SummaryModel();
            
            return View(model);
        }
        public IActionResult Test()
        {

           // var Name = _databaseservice.Getname();

            var model = new TestModel();

            return View(model);
        }

    }
}
