using AutoMapper;
using FirstDemo.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Areas.Admin.Models;

namespace WebApplication1.Profiles
{
    public class DemoProfile : Profile
    {
        public DemoProfile()
        {
            CreateMap<CreateCourseModel, Course>().ReverseMap();
            CreateMap<EditCourseModel, Course>().ReverseMap();


        }
    }
}
