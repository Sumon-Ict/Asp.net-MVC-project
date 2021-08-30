using AttendanceSystem.TNA.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class EditStudentModel
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public int StudentRollNumber { get; set; }

        private readonly IStudentService _studentService;
        public EditStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
        }
        public EditStudentModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        internal void LoadModelData(int id)
        {
            var student = _studentService.GetStudentById(id);
            Id = student.Id;
            Name = student.Name;
            StudentRollNumber = student.StudentRollNumber;
        }

        internal void Edit()
        {
            _studentService.Edit(new TNA.BusinessObject.Student {
                Id = Id,
                Name = Name,
                StudentRollNumber = StudentRollNumber
            });
        }
    }
}
