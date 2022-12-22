using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class Teacher
    {
        protected int Id { get; set; }
        private string name { get; set; }
        private string userName { get; set; }
        private string password { get; set; }
        private DateTime schedule { get; set; }
        private int noOfClasses { get; set; }

        public Teacher(string name, string userName, string password) 
        { 

        }
    }
}
