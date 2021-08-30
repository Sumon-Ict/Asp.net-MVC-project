using AttendanceSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.TNA.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public int StudentRollNumber { get; set; }
        public ICollection<Attendance> Attendances { get; set; }

    }
}
