using AttendanceSystem.TNA.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.TNA.Services
{
    public interface IStudentService
    {
        (IList<Student> records, int total, int totalDisplay) GetStudents(
            int pageIndex, int pageSize, string searchText, string sortText);
        void Add(Student student);
        void Delete(int id);
        Student GetStudentById(int id);
        void Edit(Student student);
    }
}
