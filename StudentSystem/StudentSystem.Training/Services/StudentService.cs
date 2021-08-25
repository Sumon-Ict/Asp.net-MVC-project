using Autofac;
using AutoMapper;
using StudentSystem.Training.BusinessObjects;
using StudentSystem.Training.Exceptions;
using StudentSystem.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Training.Services
{
    public class StudentService : IStudentService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;

        private readonly IMapper _mapper;

        public StudentService(ITrainingUnitOfWork trainingUnitOfWork, IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _mapper = mapper;

        }



        public void CreateStudent(Student student)
        {
            if (student == null)
                throw new InvalidParameterException("student is not provided for create");
            if (IfNameAlreadyUsed(student.Name))

                throw new DuplicateNameException("this name already exist");

            _trainingUnitOfWork.Students.Add(_mapper.Map<Entities.Student>(student));

            _trainingUnitOfWork.Save();

        }


        public void DeleteStudent(int id)
        {
            _trainingUnitOfWork.Students.Remove(id);
            _trainingUnitOfWork.Save();

        }

        public Student GetStudent(int id)
        {
            var student = _trainingUnitOfWork.Students.GetById(id);

            return _mapper.Map<Student>(student);

        }

        public (IList<Student> records, int total, int totalDisplay) GetStudents(
            int pageIndex, int pageSize, string searchText, string sortText)
        {
            var studentData = _trainingUnitOfWork.Students.GetDynamic(string.IsNullOrEmpty(searchText) ?
                null : x => x.Name.Contains(searchText), sortText, string.Empty, pageIndex, pageSize);

            var resultdata = (from student in studentData.data
                              select _mapper.Map<Student>(student)).ToList();

            return (resultdata, studentData.total, studentData.totalDisplay);

        }

        public void UpdateStudent(Student student)
        {
            if (student == null)
                throw new InvalidParameterException("studnt is not provided for update data");

            if (IfNameAlreadyUsed(student.Name, student.Id))
                throw new DuplicateNameException("this name is already used in another student");
            if (IfSamePhoneNumber(student.PhoneNumber, student.Id))
                throw new Exception("phone number is another student phone");

            var studentEntity = _trainingUnitOfWork.Students.GetById(student.Id);

            if (studentEntity != null)
            {
                _mapper.Map(student, studentEntity);
                _trainingUnitOfWork.Save();

            }

            else
                throw new InvalidOperationException("failed to update student ");


        }
        private bool IfNameAlreadyUsed(string name) =>
           _trainingUnitOfWork.Students.GetCount(x => x.Name == name) > 0;

        private bool IfNameAlreadyUsed(string name, int id) =>
            _trainingUnitOfWork.Students.GetCount(x => x.Name == name && x.Id != id) > 0;
        private bool IfSamePhoneNumber(string number, int id) =>
            _trainingUnitOfWork.Students.GetCount(x => x.PhoneNumber == number && x.Id != id) > 0;


    }
}
