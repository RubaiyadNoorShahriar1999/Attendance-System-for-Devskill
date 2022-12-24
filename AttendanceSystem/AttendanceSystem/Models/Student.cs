using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Schedule { get; set; }
        public int NoOfClasses { get; set; }
        public int AdminId { get; set; }
        public int TeacherId { get; set; }
        public Admin Admin { get; set; }
        public Teacher Teacher { get; set; }
        public List<CourseStudent> StudentCourses { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
