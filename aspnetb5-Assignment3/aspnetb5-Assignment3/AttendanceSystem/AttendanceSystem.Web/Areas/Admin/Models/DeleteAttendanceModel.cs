using AttendanceSystem.TNA.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class DeleteAttendanceModel
    {
        private readonly IAttendanceService _attendanceService;
        public DeleteAttendanceModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }
        public DeleteAttendanceModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        internal void Delete(int id)
        {
            _attendanceService.Delete(id);
        }
    }
}
