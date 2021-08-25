using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentSystem.Areas.Admin.Models;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController>logger)
        {
            _logger = logger;

        }


        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetJsonResult()
        {
            var model = new StudentListModel();
            var dataTable = new DataTablesAjaxRequestModel(Request);

            var data = model.getStudents(dataTable);
            return Json(data);

        }

        public IActionResult Create()
        {
            var model = new CreateStudentModel();

            return View(model);

        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(CreateStudentModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    model.createStudent();

                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "failed to create new Student");
                    _logger.LogError(ex, "failed to create student");

                }
            }
            return View(model);

        }

        public IActionResult Edit(int id)
        {
            var model = new EditStudentModel();
            model.LoadModelData(id);

            return View(model);

        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(EditStudentModel model)
        {
            if(ModelState.IsValid)
            {
                model.updateStudent();
            }

            return View(model);

        }
        [HttpPost,ValidateAntiForgeryToken]
            
        public IActionResult Delete(int id)
        {
            var model = new StudentListModel();
            model.deleteStudent(id);

            return RedirectToAction(nameof(Index));
        }
    }
    

}
