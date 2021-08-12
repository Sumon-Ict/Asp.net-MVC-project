using FirstDemo.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Training.Services
{
    public interface ICourseService
    {
        IList<Course> GetAllCourse();
        void EnrollStudent(Course course, Student student);
        void CreateCourse(Course course);  
        (IList<Course> records, int total, int totalDisplay) GetCourses(int pageIndex, int pageSize,
           string searchText, string sortText);
        Course GetCourse(int id);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
