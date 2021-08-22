using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBookingSystem.Areas.Admin.Models;
using TicketBookingSystem.Models;

namespace TicketBookingSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Create()
        {
            var model = new CreateCustomerModel();

            return View(model);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateCustomerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateNewCustomer();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create New Customer");
                    _logger.LogError(ex, "Create customer  Failed");
                }
            }

            return View(model);

        }

        public IActionResult Index()
        {
            var model = new CustomerListModel();

            return View(model);

        }

        public JsonResult GetCustomerData()
        {
            
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new CustomerListModel();
            var data = model.GetAllCustomer(dataTablesModel);   
            return Json(data);


        }

      
        public IActionResult Edit(int id)
        {
            var model = new EditCustomerModel();

            model.LoadModelData(id);

            return View(model);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditCustomerModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.UpDateCustomer();

                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "failed update the customer ");
                    _logger.LogError(ex, "update customer failed");

                }
            }
           
            return View(model);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new CustomerListModel();
            model.delete(id);

            return RedirectToAction(nameof(Index));



        }
    }
}
