using Autofac;
using AutoMapper;
using StudentSystem.Training.BusinessObjects;
using StudentSystem.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSystem.Areas.Admin.Models
{
    public class EditStudentModel
    {
        public int Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "student name must be less than 100 character")]
        public string Name { get; set; }
        [Required, MaxLength(150, ErrorMessage = "Address must be less than 150 character")]
        public string Address { get; set; }
        [Required, Range(typeof(DateTime), "1/1/1900", "12/8/2021")]
        public DateTime DateOfBirth { get; set; }
        public int Roll { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public double CGPA { get; set; }


        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public EditStudentModel()
        {
            _studentService = Startup.AutofacContainer.Resolve<IStudentService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }

        public EditStudentModel(IStudentService studentService, IMapper mapper)
        {
            _mapper = mapper;
            _studentService = studentService;

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
