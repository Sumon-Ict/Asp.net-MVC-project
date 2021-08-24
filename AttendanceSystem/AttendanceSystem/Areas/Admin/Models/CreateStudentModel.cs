using AttendanceSystem.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using AttendanceSystem.Training.BusinessObjects;

namespace AttendanceSystem.Areas.Admin.Models
{
    public class CreateStudentModel
    {
       // public int Id { get; set; }

        [Required,MaxLength(100,ErrorMessage ="student name must be less than 100 character")]
        public string Name { get; set; }

        [Required,Range(1,1000,ErrorMessage ="studentroll must be between 1 and 1000")]
        public int StudentRollNumber { get; set; }

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public CreateStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }

        public void createStudent()
        {
            var student = _mapper.Map<Student>(this);
            _studentService.CreateStudent(student);

        }





    }
}
