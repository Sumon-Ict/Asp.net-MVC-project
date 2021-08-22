using InventorySystem.Areas.Admin.Models;
using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController>logger)
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
            var data = model.Getproducts(dataTablesModel);
            return Json(data);


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
            if(ModelState.IsValid)
            {
                try
                {
                    model.updateProduct();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "failed to the product model");
                    _logger.LogError(ex,"failed to update product");
                }
            }
            return View(model);

        }

        public IActionResult Create()
        {
            var model = new CreateProductModel();
            return View(model);

        }

        [HttpPost,ValidateAntiForgeryToken]

        public IActionResult Create(CreateProductModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.createProduct();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "failed to create new product");
                    _logger.LogError(ex, "failed create product");
                }

            }
            return View(model);

        }

        public IActionResult Delete(int id)
        {
            var model = new ProductListModel();

            model.deleteProduct(id);

            return RedirectToAction(nameof(Index));


        }

      
    }
}
