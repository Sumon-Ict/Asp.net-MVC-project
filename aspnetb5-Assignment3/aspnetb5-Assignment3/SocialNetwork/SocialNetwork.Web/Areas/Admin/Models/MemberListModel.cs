using Autofac;
using SocialNetwork.Admin.Services;
using SocialNetwork.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Areas.Admin.Models
{
    public class MemberListModel
    {
        private readonly IMemberService _memberService;
        public MemberListModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
        }
        public MemberListModel(IMemberService memberService)
        {
            _memberService = memberService;
        }
        internal object GetMembers(DataTablesAjaxRequestModel dataTablesAjaxRequestModel)
        {
            var data = _memberService.GetMembers(
                    dataTablesAjaxRequestModel.PageIndex,
                    dataTablesAjaxRequestModel.PageSize,
                    dataTablesAjaxRequestModel.SearchText,
                    dataTablesAjaxRequestModel.GetSortText(new string[] { "Name", "DateOfBirth", "Address" })
                );
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.DateOfBirth.ToString(),
                            record.Address,
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
