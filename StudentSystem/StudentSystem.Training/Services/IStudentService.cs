using StudentSystem.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Training.Services
{
    public interface IStudentService
    {
        void CreateStudent(Student student);

        Student GetStudent(int id);
        void DeleteStudent(int id);

        void UpdateStudent(Student student);

        (IList<Student> records, int total, int totalDisplay) GetStudents(
           int pageIndex, int pageSize, string searchText, string sortText);






    }
}
