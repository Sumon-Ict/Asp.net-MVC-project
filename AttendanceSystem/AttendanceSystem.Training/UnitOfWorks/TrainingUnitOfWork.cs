using AttendanceSystem.Data;
using AttendanceSystem.Training.Contexts;
using AttendanceSystem.Training.Repositories;
using AttendanceSystem.Training.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Training.UnitOfWorks
{
  public   class TrainingUnitOfWork  : UnitOfWork, ITrainingUnitOfWork
    {
       public  IStudentRepository Students { get; private set; }
        public TrainingUnitOfWork(ITrainingContext context,IStudentRepository students)
            : base((DbContext)context)
        {
            Students = students;
        }
    }
}
