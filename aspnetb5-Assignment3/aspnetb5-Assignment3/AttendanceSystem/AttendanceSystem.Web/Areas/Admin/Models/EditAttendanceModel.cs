using AttendanceSystem.TNA.Services;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class EditAttendanceModel
    {
        public int StudentRollNumber { get; set; }
        public int AttendanceId { get; set; }
        private readonly IAttendanceService _attendanceService;
        public EditAttendanceModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }
        public EditAttendanceModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        internal void Edit()
        {
            _attendanceService.Edit(StudentRollNumber, AttendanceId);
        }

        internal void setId(int id)
        {
            AttendanceId = id;
        }
    }
}
