using StudentSystem.Data;
using StudentSystem.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Training.Repositories
{
    public interface IStudentRepository : IRepository<Student, int>
    {

    }
}
