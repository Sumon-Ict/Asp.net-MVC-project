using AttendanceSystem.Data.Repositories;
using AttendanceSystem.TNA.Contexts;
using AttendanceSystem.TNA.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.TNA.Repositories
{
    public class AttendanceRepository : Repository<Attendance, int>, IAttendanceRepository
    {
        public AttendanceRepository(ITNADbContext tNADbContext) :
            base((DbContext)tNADbContext)
        {

        }
    }
}
