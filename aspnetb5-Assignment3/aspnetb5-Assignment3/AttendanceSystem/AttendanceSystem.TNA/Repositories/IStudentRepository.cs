using AttendanceSystem.Data.Repositories;
using AttendanceSystem.TNA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.TNA.Repositories
{
    public interface IStudentRepository : IRepository<Student, int>
    {
    }
}
