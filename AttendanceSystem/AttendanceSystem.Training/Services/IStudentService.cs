using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceSystem.Training.BusinessObjects;

namespace AttendanceSystem.Training.Services
{
    public interface IStudentService
    {
        void CreateStudent(Student student);

        void UpdateStudent(Student student);
        void DeleteStudent(int id);

        Student GetStudent(int id);

        (IList<Student> records, int total, int totalDisplay) GetStudents(int pageIndex, int pageSize,
            string searchText, string sortText);








    }
}
