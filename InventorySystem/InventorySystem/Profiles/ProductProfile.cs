using AutoMapper;
using InventorySystem.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BO = InventorySystem.Training.BusinessObjects;

namespace InventorySystem.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductModel, BO.Product>().ReverseMap();
            CreateMap<EditProductModel, BO.Product>().ReverseMap();


        }
    }
}
