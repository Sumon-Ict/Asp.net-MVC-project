using AutoMapper;
using ECommerceSystem.Areas.Admin.Models;
using ECommerceSystem.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSystem.Profiles
{
    public class DemoProfile : Profile
    {
        public DemoProfile()
        {
            CreateMap<CreateProductModel, Product>().ReverseMap();
            CreateMap<EditProductModel, Product>().ReverseMap();


        }
    }
}
