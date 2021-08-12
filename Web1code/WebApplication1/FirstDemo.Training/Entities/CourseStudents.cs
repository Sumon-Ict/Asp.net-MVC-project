using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo.Training.Entities
{
   public  class CourseStudents
    {
        public int CouserId { get; set; }
        public Course course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
