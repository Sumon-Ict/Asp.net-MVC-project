using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = FirstDemo.Training.Entities;
using BO = FirstDemo.Training.BusinessObjects;

namespace FirstDemo.Training.Profiles
{
  public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<EO.Course, BO.Course>().ReverseMap();

        }

    }
}
