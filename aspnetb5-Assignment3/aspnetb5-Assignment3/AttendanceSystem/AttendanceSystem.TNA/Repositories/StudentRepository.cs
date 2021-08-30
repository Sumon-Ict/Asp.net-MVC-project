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
    public class StudentRepository : Repository<Student, int>, IStudentRepository
    {
        public StudentRepository(ITNADbContext tNADbContext):
            base((DbContext)tNADbContext)
        {

        }
    }
}
