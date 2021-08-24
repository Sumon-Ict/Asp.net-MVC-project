using AttendanceSystem.Areas.Admin.Models;
using AttendanceSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Areas.Admin.Controllers
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
            var model = new StudentListModel();

            return View(model);
            
        }

        public JsonResult GetStudentResult()
        {
            var model = new StudentListModel();
            var dataTables = new DataTablesAjaxRequestModel(Request);

            var data = model.getStudents(dataTables);

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
                    ModelState.AddModelError("", "failed to create new  student ");
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
        public IActionResult Delete(int id)
        {
            var model = new StudentListModel();
            model.deleteStudent(id);

            return RedirectToAction(nameof(Index));

        }

    }
}
