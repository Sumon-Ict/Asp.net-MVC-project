using AttendanceSystem.Data.UnitOfWorks;
using AttendanceSystem.TNA.Contexts;
using AttendanceSystem.TNA.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.TNA.UnitOfWorks
{
    public class TNAUnitOfWork : UnitOfWork, ITNAUnitOfWork
    {
        public TNAUnitOfWork(ITNADbContext tNADbContext,IStudentRepository students, IAttendanceRepository attendances):
            base((DbContext)tNADbContext)
        {
            Students = students;
            Attendances = attendances;
        }

        public IStudentRepository Students { get; private set; }

        public IAttendanceRepository Attendances { get; private set; }
    }
}
