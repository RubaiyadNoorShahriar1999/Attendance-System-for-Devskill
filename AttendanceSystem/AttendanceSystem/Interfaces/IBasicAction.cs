using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Interfaces
{
    public interface IBasicAction<Type>
    {
        public bool Create(Type type);
        public List<Type> Read();
        public bool Update(Type type);
        public bool Delete(int id);
    }
}
