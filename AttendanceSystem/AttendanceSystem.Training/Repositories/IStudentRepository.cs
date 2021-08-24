using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystem.Data;
using AttendanceSystem.Training.Entities;

namespace AttendanceSystem.Training.Repositories
{
  public  interface IStudentRepository : IRepository<Student,int>
    {
    }

}
