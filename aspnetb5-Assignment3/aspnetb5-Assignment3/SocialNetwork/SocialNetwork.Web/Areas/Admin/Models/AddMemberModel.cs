using Autofac;
using SocialNetwork.Admin.BusinessObject;
using SocialNetwork.Admin.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class AddMemberModel
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; }
        private readonly IMemberService _memberService;
        public AddMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }
        public AddMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        internal void AddMember()
        {
            _memberService.Add(new Member
            {
                Name = Name,
                DateOfBirth = DateOfBirth,
                Address = Address
            });
        }
    }
}
