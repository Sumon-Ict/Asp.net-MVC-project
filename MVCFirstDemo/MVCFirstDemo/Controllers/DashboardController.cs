using Microsoft.AspNetCore.Mvc;
using MVCFirstDemo.Models;
using MVCFirstDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFirstDemo.Controllers
{
    public class DashboardController : Controller
    {

        private IDatabaseService _databaseService;

        public DashboardController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
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

        public IActionResult DatabaseService()
        {
            var result = _databaseService.Name();


            return View();

        }
    }
}
