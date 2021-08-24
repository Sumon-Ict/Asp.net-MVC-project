using AttendanceSystem.Training.UnitOfWorks;
using AutoMapper;
using AttendanceSystem.Training.BusinessObjects;
using AttendanceSystem.Training.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Training.Services
{
    public class StudentService : IStudentService
    {

        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IMapper _mapper;
       // private readonly IDateTimeUtility _dateTimeUtility;


        public StudentService(ITrainingUnitOfWork trainingUnitOfWork, 
            IMapper mapper) 
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _mapper = mapper;
           // _dateTimeUtility = dateTimeUtility;


        }
      
       

        private bool IfNameAlreadyUsed(string name) =>
            _trainingUnitOfWork.Students.GetCount(x => x.Name == name) > 0;

        private bool IfNameAlreadyUsed(string name, int id) =>
            _trainingUnitOfWork.Students.GetCount(x => x.Name == name && x.Id != id) > 0;

       public void CreateStudent(Student student)
        {
            if (student == null)
                throw new InvalidParameterException("student is not provided");
            if (IfNameAlreadyUsed(student.Name))
                throw new DuplicateNameException("this name already used");

           
            _trainingUnitOfWork.Students.Add(_mapper.Map<Entities.Student>(student));
            _trainingUnitOfWork.Save();

            
        }

        public Student GetStudent(int id)
        {
         var student=   _trainingUnitOfWork.Students.GetById(id);

            return _mapper.Map<Student>(student);
      
        }

        public void DeleteStudent(int id)
        {
            _trainingUnitOfWork.Students.Remove(id);
            _trainingUnitOfWork.Save();

        }

        public void UpdateStudent(Student student)
        {
            if (student == null)
                throw new InvalidParameterException("student is not provided for the update");
            if (IfNameAlreadyUsed(student.Name, student.Id))

                throw new InvalidOperationException("this name already used in anather student");

            var studentEntity = _trainingUnitOfWork.Students.GetById(student.Id);
            if (studentEntity != null)
            {
                _mapper.Map(student, studentEntity);
                _trainingUnitOfWork.Save();

            }

            else
                throw new InvalidOperationException("student is not found");


        }

        public (IList<Student> records, int total, int totalDisplay) GetStudents(int pageIndex,
            int pageSize, string searchText, string sortText)
        {
            var studentData = _trainingUnitOfWork.Students.GetDynamic(
                string.IsNullOrEmpty(searchText)? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var resutdata = (from student in studentData.data
                             select _mapper.Map<Student>(student)).ToList();

            return (resutdata, studentData.total, studentData.totalDisplay);

        }
    }
}
