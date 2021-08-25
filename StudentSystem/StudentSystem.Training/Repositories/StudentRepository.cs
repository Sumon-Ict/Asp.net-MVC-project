using Microsoft.EntityFrameworkCore;
using StudentSystem.Data;
using StudentSystem.Training.Contexts;
using StudentSystem.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Training.Repositories
{
    public class StudentRepository : Repository<Student, int>, IStudentRepository
    {
        public StudentRepository(ITrainingDbContext context)
             : base((DbContext)context)
        {

        }

    }
}
