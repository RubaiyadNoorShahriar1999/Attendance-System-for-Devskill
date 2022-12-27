using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public double Fees { get; set; }
        public DateTime ClassStartDate { get; set; }
        public string ClassTime { get; set; }
        public int NoOfClasses { get; set; }
        public Admin Admin { get; set; }
        public Teacher Teacher { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
        public List<Attendance> Attendances { get; set; }

        [ForeignKey("AdminId")]
        public int AdminId { get; set; }

        [ForeignKey("TeacherId")]
        public int? TeacherId { get; set; }
    }
}
