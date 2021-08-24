using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystem.Data;
using Microsoft.EntityFrameworkCore;
using AttendanceSystem.Training.Contexts;
using AttendanceSystem.Training.Entities;


namespace AttendanceSystem.Training.Repositories
{
  public  class StudentRepository : Repository<Student, int>,  IStudentRepository
    {

        public StudentRepository(ITrainingContext context)
            : base ((DbContext)context)
        {

        }

    }

}
