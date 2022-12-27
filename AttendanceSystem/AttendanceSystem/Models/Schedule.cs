using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class Schedule
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string ClassTime { get; set; }
        public int NoOfClasses { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set;}
        public Student Student { get; set; }
    }
}
