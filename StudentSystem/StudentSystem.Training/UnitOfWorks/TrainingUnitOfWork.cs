using Microsoft.EntityFrameworkCore;
using StudentSystem.Data;
using StudentSystem.Training.Contexts;
using StudentSystem.Training.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IStudentRepository Students { get; private set; }

        public TrainingUnitOfWork(ITrainingDbContext context, IStudentRepository students)
            : base((DbContext)context)
        {
            Students = students;
        }


    }
}
