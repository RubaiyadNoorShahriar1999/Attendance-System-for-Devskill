using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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

        [ForeignKey("AdminId")]
        public int AdminId { get; set; }
        public Admin Admin { get; set; }

        [ForeignKey("TeacherId")]
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<CourseStudent> StudentCourses { get; set; }
        public List<Attendance> Attendances { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
