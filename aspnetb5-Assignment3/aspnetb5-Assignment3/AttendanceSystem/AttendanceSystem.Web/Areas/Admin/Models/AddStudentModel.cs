using AttendanceSystem.TNA.BusinessObject;
using AttendanceSystem.TNA.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class AddStudentModel
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public int StudentRollNumber { get; set; }

        private readonly IStudentService _studentService;
        public AddStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        public AddStudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }
        internal void AddStudent()
        {
            _studentService.Add(
                new Student
                {
                    Name = Name,
                    StudentRollNumber = StudentRollNumber
                });
        }
    }
}
