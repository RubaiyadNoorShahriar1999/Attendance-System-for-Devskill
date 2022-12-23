using System;
using System.Collections.Generic;
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
    }
}
