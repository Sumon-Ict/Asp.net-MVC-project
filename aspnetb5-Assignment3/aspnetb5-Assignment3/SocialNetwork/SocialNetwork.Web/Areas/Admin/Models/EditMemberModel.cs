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
    public class EditMemberModel
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; }
        private readonly IMemberService _memberService;
        public EditMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }
        public EditMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }
        internal void LoadModelData(int id)
        {
            var member = _memberService.GetMemberById(id);
            Id = member.Id;
            Name = member.Name;
            Address = member.Address;
            DateOfBirth = member.DateOfBirth;
        }

        internal void Edit()
        {
            _memberService.Edit(new Member
            {
                Id = Id,
                Name = Name,
                Address = Address,
                DateOfBirth = DateOfBirth
            });
        }
    }
}
