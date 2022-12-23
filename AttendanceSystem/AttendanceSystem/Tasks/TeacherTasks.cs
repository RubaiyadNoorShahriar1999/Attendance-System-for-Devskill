using AttendanceSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Tasks
{
    public class TeacherTasks : IBasicAction<Type>
    {
        public bool Create(Type type)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Type> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
