using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class Student : User
    {
        private string Name { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        private DateTime schedule;

        public Student() 
        {

        }
    }
}
