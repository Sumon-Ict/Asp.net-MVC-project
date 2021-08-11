using Autofac;
using AutoMapper;
using FirstDemo.Training.BusinessObjects;
using FirstDemo.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public class EditCourseModel
    {
        [Required,Range(1,5000)]
        public int Id { get; set; }

        [Required, MaxLength(200, ErrorMessage = "Title should be less than 200 charcaters")]
        public string Title { get; set; }

        [Required, Range(100, 50000)]
        public int Fees { get; set; }

        [Required, Range(typeof(DateTime), "1/1/1971", "12/12/2030")]
        public DateTime StartDate { get; set; }

        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;


        public EditCourseModel()
        {
            _courseService = Startup.AutofacContainer.Resolve<ICourseService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public EditCourseModel(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        public void LoadModelData(int id)
        {
            var course = _courseService.GetCourse(id);

            _mapper.Map(course,this);
            //Id = course.Id;
            //Title = course.Title;
            //Fees = course.Fees;
            //StartDate = course.StartDate;

        }

        internal void Update()
        {
            var course = _mapper.Map<Course>(this);

            //   new Course
            //{
            //    Id=Id,
            //    Fees=Fees,
            //    Title=Title,
            //    StartDate=StartDate

            //};
            _courseService.UpdateCourse(course);
        }
    }
}
