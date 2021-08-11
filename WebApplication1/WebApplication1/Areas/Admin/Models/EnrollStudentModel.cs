using Autofac;
using FirstDemo.Training.BusinessObjects;
using FirstDemo.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class EnrollStudentModel
    {

        public int StudentId { get; set; }
        public string CourseName { get; set; }
        private readonly ICourseService _courseService;

        public EnrollStudentModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public EnrollStudentModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public void Enrollstudent()
        {
            var courses = _courseService.GetAllCourse();
            var selectedCourse = courses.Where(t => t.Title == CourseName).FirstOrDefault();

            var student = new Student
            {
                Id = StudentId,
                Name = "sumon",
                DateOfBirth = DateTime.Now

            };

            _courseService.EnrollStudent(selectedCourse, student);

        }

       
    }
}
