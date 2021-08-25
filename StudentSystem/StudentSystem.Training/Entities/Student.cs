using StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Training.Entities
{
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Roll { get; set; }

        public string PhoneNumber { get; set; }
        public double CGPA { get; set; }
    }
}
