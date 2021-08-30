using AttendanceSystem.Web.Areas.Admin.Models;
using AttendanceSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AttendanceController : Controller
    {
        private readonly ILogger<AttendanceController> _logger;
        public AttendanceController(ILogger<AttendanceController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAttendances()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new AttendanceListModel();
            var data = model.GetAttendances(dataTablesModel);
            return Json(data);
        }
        public IActionResult Add()
        {
            var model = new AddAttendanceModel();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(AddAttendanceModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _logger.LogError(ex, "Add Attendance failed");
                }
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = new EditAttendanceModel();
            model.setId(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditAttendanceModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _logger.LogError(ex, "Edit Attendance failed");
                }
            }
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new DeleteAttendanceModel();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
