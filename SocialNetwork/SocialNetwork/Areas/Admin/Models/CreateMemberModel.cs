using AutoMapper;
using SocialNetwork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using SocialNetwork.Training.BusinessObjects;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Areas.Admin.Models
{
    public class CreateMemberModel
    {
       // public int Id { get; set; }
       [Required,MaxLength(100,ErrorMessage ="member name should be less than 100 character")]
        public string Name { get; set; }

        [Required,Range(typeof(DateTime),"1/1/1900","1/1/2022")]
        public  DateTime DateOfBirth { get; set; }

        [Required,MaxLength(100,ErrorMessage ="Address name must be less than 100 character")]
        public string Address { get; set; }


        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        public CreateMemberModel(IMemberService memberService,IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;

        }
        public CreateMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }

        public void createMember()
        {
            var member = _mapper.Map<Member>(this);

            _memberService.CreateMember(member);

        }


    }
}
