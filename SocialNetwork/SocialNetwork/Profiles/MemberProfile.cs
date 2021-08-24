using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BO = SocialNetwork.Training.BusinessObjects;
using SocialNetwork.Areas.Admin.Models;


namespace SocialNetwork.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<CreateMemberModel, BO.Member>().ReverseMap();
            CreateMap<EditMemberModel, BO.Member>().ReverseMap();


        }
    }
}
