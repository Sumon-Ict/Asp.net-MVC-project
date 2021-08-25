using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = StudentSystem.Training.BusinessObjects;
using EO = StudentSystem.Training.Entities;

namespace StudentSystem.Training.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<BO.Student, EO.Student>().ReverseMap();
            CreateMap<BO.Student, EO.Student>().ReverseMap();

        }
    }
}
