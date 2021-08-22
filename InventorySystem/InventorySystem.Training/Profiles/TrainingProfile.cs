using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = InventorySystem.Training.Entities;
using BO = InventorySystem.Training.BusinessObjects;
namespace InventorySystem.Training.Profiles
{
   public  class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<EO.Product, BO.Product>().ReverseMap();
            CreateMap<EO.Stock, BO.Stock>().ReverseMap();


        }
    }
}
