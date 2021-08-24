using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO = SocialNetwork.Training.BusinessObjects;
using EO = SocialNetwork.Training.Entities;


namespace SocialNetwork.Training.Profiles
{
   public  class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<BO.Member, EO.Member>().ReverseMap();

        }
    }
}
