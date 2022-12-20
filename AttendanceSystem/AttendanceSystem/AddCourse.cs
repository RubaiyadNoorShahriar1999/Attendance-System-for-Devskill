using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class AddCourse
    {
        protected int courseId { get; set; }
        protected string courseName { get; set; }
        protected DateTime schedule { get; set; } 
        protected int fees { get; set; }

        public AddCourse() { }
    }
}
