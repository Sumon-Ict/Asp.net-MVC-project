using AttendanceSystem.Training.BusinessObjects;
using AttendanceSystem.Training.Services;
using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Areas.Admin.Models
{
    public class EditStudentModel
    {
        public int Id { get; set; }

        [Required, MaxLength(100, ErrorMessage = "student name must be less than 100 character")]
        public string Name { get; set; }

        [Required, Range(1, 1000, ErrorMessage = "studentroll must be between 1 and 1000")]
        public int StudentRollNumber { get; set; }

        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public EditStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }

        public EditStudentModel(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public void LoadModelData(int id)
        {
            var student = _studentService.GetStudent(id);
            _mapper.Map(student, this);
        }

        public void updateStudent()
        {
            var student = _mapper.Map<Student>(this);

            _studentService.UpdateStudent(student);


        }



    }
}
