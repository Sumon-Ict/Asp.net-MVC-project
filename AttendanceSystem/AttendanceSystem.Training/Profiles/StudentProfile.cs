using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = AttendanceSystem.Training.BusinessObjects;
using EO = AttendanceSystem.Training.Entities;


namespace SocialNetwork.Training.Profiles
{
   public  class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<BO.Student, EO.Student>().ReverseMap();

        }
    }
}
