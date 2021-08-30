using AttendanceSystem.Data.UnitOfWorks;
using AttendanceSystem.TNA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.TNA.UnitOfWorks
{
    public interface ITNAUnitOfWork : IUnitOfWork
    {
        IStudentRepository Students { get; }
        IAttendanceRepository Attendances { get; }
    }
}
