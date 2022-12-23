using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Tasks
{
    public class StudentTasks : IBasicAction<Student>
    {
        public bool Create(Student type)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(Student type)
        {
            throw new NotImplementedException();
        }
    }
}
