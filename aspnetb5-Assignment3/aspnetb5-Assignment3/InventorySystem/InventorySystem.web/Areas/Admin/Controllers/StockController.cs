using InventorySystem.web.Areas.Admin.Models;
using InventorySystem.web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetStocks()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new StockListModel();
            var data = model.GetStocks(dataTablesModel);
            return Json(data);
        }
        public IActionResult Sell(int id = 0)
        {
            var model = new EditStockModel();
            model.LoadModelData(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Sell(EditStockModel model)
        {
            if (ModelState.IsValid)
            {
                model.Sell();
            }
            return View(model);
        }
        public IActionResult Buy(int id = 0)
        {
            var model = new EditStockModel();
            model.LoadModelData(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Buy(EditStockModel model)
        {
            if (ModelState.IsValid)
            {
                model.Buy();
            }
            return View(model);
        }
    }
}
