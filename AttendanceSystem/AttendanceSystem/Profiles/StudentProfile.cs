using AttendanceSystem.Areas.Admin.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BO = AttendanceSystem.Training.BusinessObjects;
namespace AttendanceSystem.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentModel, BO.Student>().ReverseMap();
            CreateMap<EditStudentModel, BO.Student>().ReverseMap();

        }
    }
}
