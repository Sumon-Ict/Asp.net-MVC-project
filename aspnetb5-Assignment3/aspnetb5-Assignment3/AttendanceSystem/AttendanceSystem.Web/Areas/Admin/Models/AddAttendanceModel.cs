using AttendanceSystem.TNA.Services;
using AttendanceSystem.TNA.UnitOfWorks;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceSystem.Web.Areas.Admin.Models
{
    public class AddAttendanceModel
    {
        public int StudentRollNumber { get; set; }
        private readonly IAttendanceService _attendanceService;
        public AddAttendanceModel()
        {
            _attendanceService = Startup.AutofacContainer.Resolve<IAttendanceService>();
        }
        public AddAttendanceModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        internal void Add()
        {
            _attendanceService.Add(StudentRollNumber);
        }
    }
}
