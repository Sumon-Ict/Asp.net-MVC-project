using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.TNA.BusinessObject
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int StudentRoll { get; set; }
        public DateTime Date { get; set; }
    }
}
