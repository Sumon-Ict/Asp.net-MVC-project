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
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetStudents()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            var model = new StudentListModel();
            var data = model.GetStudents(dataTablesModel);
            return Json(data);
        }
        public IActionResult Add()
        {
            var model = new AddStudentModel();
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(AddStudentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.AddStudent();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    _logger.LogError(ex, "Add student failed");
                }
            }
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new DeleteStudentModel();
            model.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var model = new EditStudentModel();
            model.LoadModelData(id);
            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditStudentModel model)
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
                    _logger.LogError(ex, "Edit student failed");
                }
                
            }
            return View(model);
        }
    }
}
