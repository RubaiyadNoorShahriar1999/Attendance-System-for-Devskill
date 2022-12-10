using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class Admin : User , ClassSchedule
    {
        private string Name { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        public DateTime schedule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime ClassSchedule.schedule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int ClassSchedule.number { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Admin() { }
    }
}
