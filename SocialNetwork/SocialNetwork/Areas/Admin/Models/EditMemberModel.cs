using Autofac;
using AutoMapper;
using SocialNetwork.Training.BusinessObjects;
using SocialNetwork.Training.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Areas.Admin.Models
{
    public class EditMemberModel
    {
        public int Id { get; set; }

        [Required, MaxLength(100, ErrorMessage = "member name should be less than 100 character")]
        public string Name { get; set; }

        [Required, Range(typeof(DateTime), "1/1/1900", "1/1/2022")]
        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Address name must be less than 100 character")]
        public string Address { get; set; }

        private readonly IMemberService _memberService;

        private readonly IMapper _mapper;


        public EditMemberModel(IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;

        }
        public EditMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }

        public void LoadModelData(int id)
        {
            var member = _memberService.GetMember(id);

            _mapper.Map(member, this);

        }

        public void updateMember()
        {

            var member = _mapper.Map<Member>(this);

            _memberService.UpdateMember(member);

        }

    }
}
