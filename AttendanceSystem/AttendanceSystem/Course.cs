using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class Course
    {
        public int Id { get; set; }
        public string courseName { get; set; }
        public double fees { get; set; }
        public DateTime ClassStartDate { get; set; }
    }
}
    