using AttendanceSystem.TNA.BusinessObject;
using AttendanceSystem.TNA.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.TNA.Services
{
    public class StudentService : IStudentService
    {
        private readonly ITNAUnitOfWork _tNAUnitOfWork;
        public StudentService(ITNAUnitOfWork tNAUnitOfWork)
        {
            _tNAUnitOfWork = tNAUnitOfWork;
        }

        public void Add(Student student)
        {
            if (student == null)
                throw new InvalidOperationException("Student not provided");
            if (isRollExist(student.StudentRollNumber))
            {
                throw new Exception("Roll Number Already exist");
            }
            else
            {
                try
                {
                    _tNAUnitOfWork.Students.Add(new Entities.Student
                    {
                        Name = student.Name,
                        StudentRollNumber = student.StudentRollNumber
                    });
                    _tNAUnitOfWork.Save();
                }
                catch
                {
                    throw new Exception("Student not added to db");
                }
            }
        }

        public void Delete(int id)
        {
            try
            {
                _tNAUnitOfWork.Students.Remove(id);
                _tNAUnitOfWork.Save();
            }
            catch
            {
                throw new Exception("Student not removed");
            }
        }

        public void Edit(Student student)
        {
            if (student == null)
                throw new InvalidOperationException("Student not provided");
            if (isRollExist(student.StudentRollNumber, student.Id))
            {
                throw new Exception("Roll Number Already exist");
            }
            else
            {
                var studentEntity = _tNAUnitOfWork.Students.GetById(student.Id);
                if (studentEntity != null)
                {
                    try
                    {
                        studentEntity.Name = student.Name;
                        studentEntity.StudentRollNumber = student.StudentRollNumber;
                        _tNAUnitOfWork.Save();
                    }
                    catch
                    {
                        throw new Exception("Not changed student");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Couldn't find Student");
                }
            }
        }

        public (IList<Student> records, int total, int totalDisplay) GetStudents(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var studentData = _tNAUnitOfWork.Students.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText), sortText,
                "", pageIndex, pageSize);
            var resultData = (from student in studentData.data
                              select new Student
                              {
                                  Id = student.Id,
                                  Name = student.Name,
                                  StudentRollNumber = student.StudentRollNumber
                              }).ToList();
            return (resultData, studentData.total, studentData.totalDisplay);
        }

        public Student GetStudentById(int id)
        {
            var studentEntity = _tNAUnitOfWork.Students.GetById(id);
            return new Student
            {
                Id = studentEntity.Id,
                Name = studentEntity.Name,
                StudentRollNumber = studentEntity.StudentRollNumber
            };
        }
        public bool isRollExist(int roll) => _tNAUnitOfWork.Students.GetCount(s =>
            s.StudentRollNumber == roll) > 0;
        public bool isRollExist(int roll, int id) => _tNAUnitOfWork.Students.GetCount(s =>
            s.StudentRollNumber == roll && s.Id !=id) > 0;
    }
}
