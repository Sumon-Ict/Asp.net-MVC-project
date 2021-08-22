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
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;

        public TicketController(ILogger<TicketController>logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new TicketListModel();

            return View(model);
        }

        public JsonResult GetTicketData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);

            var model = new TicketListModel();
            var data = model.gettickets(dataTablesModel);

            return Json(data);

        }

        public IActionResult Create()
        {
            var model = new CreateTicketModel();


            return View(model);

        }

        [HttpPost,ValidateAntiForgeryToken]

        public IActionResult Create(CreateTicketModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.createticket();
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "failed to create ticket");
                    _logger.LogError(ex, "Fiale to create ticket ");

                }
            }

            return View(model);

        }
        public IActionResult Edit(int id)
        {
            var model = new EditTicketModel();

            model.LoadModelData(id);

            return View(model);

        }

        [HttpPost,ValidateAntiForgeryToken]

        public IActionResult Edit(EditTicketModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.UpdateTicket();

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "failed update the customer ");
                    _logger.LogError(ex, "update customer failed");

                }
            }

            return View(model);

        }
        public IActionResult Delete(int id)
        {
            var model = new TicketListModel();
            model.delete(id);

            return RedirectToAction(nameof(Index));

        }

    }
}
