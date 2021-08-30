using AttendanceSystem.TNA.BusinessObject;
using AttendanceSystem.TNA.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.TNA.Services
{
    class AttendanceService : IAttendanceService
    {
        private readonly ITNAUnitOfWork _tNAUnitOfWork;
        public AttendanceService(ITNAUnitOfWork tNAUnitOfWork)
        {
            _tNAUnitOfWork = tNAUnitOfWork;
        }
        public void Add(int studentRoll)
        {
            try
            {
                var studentEntity = _tNAUnitOfWork.Students.GetEntity(s => s.StudentRollNumber == studentRoll);
                if (studentEntity != null)
                {
                    var attendanceEntity = new Entities.Attendance
                    {
                        StudentId = studentEntity.Id,
                        Date = DateTime.Now
                    };
                    _tNAUnitOfWork.Attendances.Add(attendanceEntity);
                    _tNAUnitOfWork.Save();
                }
                else
                {
                    throw new Exception("Roll number not in khata");
                }
            }
            catch
            {
                throw new Exception("Roll number not in khata");
            }
            
        }

        public void Delete(int id)
        {
            _tNAUnitOfWork.Attendances.Remove(id);
            _tNAUnitOfWork.Save();
        }

        public void Edit(int studentRoll, int attendanceId)
        {
            var studentEntity = _tNAUnitOfWork.Students.GetEntity(s => s.StudentRollNumber == studentRoll);
            if (studentEntity != null)
            {
                try
                {
                    var attendanceEntity = _tNAUnitOfWork.Attendances.GetById(attendanceId);
                    attendanceEntity.StudentId = studentEntity.Id;
                    _tNAUnitOfWork.Save();
                }
                catch
                {
                    throw new Exception("Attendance id not found");
                }
            }
            else
            {
                throw new Exception("Roll number not in khata");
            }
        }

        public Attendance GetAttendance(int id)
        {
            throw new NotImplementedException();
        }

        public (IList<Attendance> records, int total, int totalDisplay) GetAttendances(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var attendanceData = _tNAUnitOfWork.Attendances.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Student.Name.Contains(searchText), null,
                "", pageIndex, pageSize);
            var resultData = (from attendance in attendanceData.data
                              select new Attendance
                              {
                                  StudentName = attendance.Student.Name,
                                  StudentRoll = attendance.Student.StudentRollNumber,
                                  Id = attendance.Id,
                                  Date = attendance.Date

                              }).ToList();
            return (resultData, attendanceData.total, attendanceData.totalDisplay);
        }
    }
}
