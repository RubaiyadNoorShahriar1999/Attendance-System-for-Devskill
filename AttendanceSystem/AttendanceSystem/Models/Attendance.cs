using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class Attendance
    {
        public string Present { get; set; }
        public DateTime Time { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
