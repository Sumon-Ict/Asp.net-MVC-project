using Autofac;
using SocialNetwork.Admin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class DeleteMemberModel
    {
        private readonly IMemberService _memberService;
        public DeleteMemberModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }
        public DeleteMemberModel(IMemberService memberService)
        {
            _memberService = memberService;
        }

        internal void Delete(int id)
        {
            _memberService.Delete(id);
        }
    }
}
