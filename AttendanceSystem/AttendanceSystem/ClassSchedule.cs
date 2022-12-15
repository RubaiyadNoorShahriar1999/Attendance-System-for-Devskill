using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public interface ClassSchedule
    {
        DateTime schedule { get; set; }
        protected int number { get; set; }
    }
}
