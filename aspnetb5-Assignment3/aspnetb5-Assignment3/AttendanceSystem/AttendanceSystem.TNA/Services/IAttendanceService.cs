using AttendanceSystem.TNA.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.TNA.Services
{
    public interface IAttendanceService
    {
        (IList<Attendance> records, int total, int totalDisplay) GetAttendances(
            int pageIndex, int pageSize, string searchText, string sortText);
        void Add(int studentRoll);
        void Delete(int id);
        Attendance GetAttendance(int id);
        void Edit(int studentRoll, int attendanceId);
    }
}
