using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var model = new CourseListModel();

            return View(model);
        }
        public JsonResult GetCourseData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);

            var model = new CourseListModel();
            var data = model.GetCourses(dataTablesModel);

            return Json(data);

        }

        public IActionResult Enroll()
        {
            var model =new  EnrollStudentModel();
            return View(model);


        }
        [HttpPost]
        public IActionResult Enroll(EnrollStudentModel model)
        {
            if(ModelState.IsValid)
            { 
               model.Enrollstudent();
                
            }
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Create()
        {
            var model = new CreateCourseModel();
            return View(model);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateCourseModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.CreateCourse();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Failed to create course");
                    _logger.LogError(ex, "Create Course Failed");
                }
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = new EditCourseModel();
            model.LoadModelData(id);
            return View();

        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EditCourseModel model)
        {
            if(ModelState.IsValid)
            {
                model.Update();
            }
           
            return View(model);

        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = new CourseListModel();
            model.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
 