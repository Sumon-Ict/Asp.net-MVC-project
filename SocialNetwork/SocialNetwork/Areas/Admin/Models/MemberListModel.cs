using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Training.BusinessObjects;
using SocialNetwork.Training.Services;
using AutoMapper;
using Autofac;
using SocialNetwork.Models;

namespace SocialNetwork.Areas.Admin.Models
{
    public class MemberListModel
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;

        public MemberListModel()
        {
            _memberService = Startup.AutofacContainer.Resolve<IMemberService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();

        }
        public MemberListModel(IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;

        }

        internal object getmembers(DataTablesAjaxRequestModel tableModel)
        {


            var data = _memberService.GetMembers(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "DateOfBirth", "Address" }));

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
                        }
                    ).ToArray()
            };
        }

        public void delete(int id)
        {
            _memberService.DeleteMember(id);

        }


    }
}

