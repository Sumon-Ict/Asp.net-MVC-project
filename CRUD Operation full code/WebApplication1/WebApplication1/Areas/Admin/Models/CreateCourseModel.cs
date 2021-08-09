using FirstDemo.Training.Services;
using System;
using Autofac;
using FirstDemo.Training.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Areas.Admin.Models
{
    public class CreateCourseModel
    {
        [Required, MaxLength(200, ErrorMessage = "Title should be less than 200 charcaters")]
        public string Title { get; set; }
        [Required, Range(100, 50000)]
        public int Fees { get; set; }
        [Required, Range(typeof(DateTime), "1/1/1971", "12/12/2030")]
        public DateTime StartDate { get; set; }

        private readonly ICourseService _courseService;

        public CreateCourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
        }
        public CreateCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

      internal void CreateCourse()
        {
            var course = new Course
            {
                Title = Title,
                Fees = Fees,
                StartDate = StartDate

            };
            _courseService.CreateCourse(course);

        }
            

    }
}
