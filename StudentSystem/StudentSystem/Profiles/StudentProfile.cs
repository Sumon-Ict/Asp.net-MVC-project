using AutoMapper;
using StudentSystem.Areas.Admin.Models;
using StudentSystem.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSystem.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentModel, Student>().ReverseMap();
            CreateMap<EditStudentModel, Student>().ReverseMap();

        }
    }
}
