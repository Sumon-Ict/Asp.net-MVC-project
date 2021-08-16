using ECommerceSystem.Areas.Admin.Models;
using ECommerceSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var model = new ProductListModel();

            return View(model);
        }
        public JsonResult GetProductData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);

            var model = new ProductListModel();
            var data = model.GetProducts(dataTablesModel);

            return Json(data);

        }
      
        public IActionResult Create()
        {
            var model = new CreateProductModel();
            return View(model);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateProduct();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create product");
                    _logger.LogError(ex, "Create product  Failed");
                }
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = new EditProductModel();
            model.LoadModelData(id);
            return View(model);

        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditProductModel model)
        {
            if (ModelState.IsValid)
            {
                model.Update();
            }

            return View(model);

        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new ProductListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
