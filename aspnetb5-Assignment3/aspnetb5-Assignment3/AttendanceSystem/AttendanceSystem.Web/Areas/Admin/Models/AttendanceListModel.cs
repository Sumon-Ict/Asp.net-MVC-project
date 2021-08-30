using AttendanceSystem.TNA.Services;
using AttendanceSystem.Web.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class AttendanceListModel
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceListModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }
        public AttendanceListModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        internal object GetAttendances(DataTablesAjaxRequestModel dataTablesAjaxRequestModel)
        {
            var data = _attendanceService.GetAttendances(
                    dataTablesAjaxRequestModel.PageIndex,
                    dataTablesAjaxRequestModel.PageSize,
                    dataTablesAjaxRequestModel.SearchText,
                    dataTablesAjaxRequestModel.GetSortText(new string[] {})
                );
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.StudentName,
                            record.StudentRoll.ToString(),
                            record.Date.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
