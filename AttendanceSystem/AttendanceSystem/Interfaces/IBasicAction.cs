using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Interfaces
{
    public interface IBasicAction<Type>
    {
        public Type Create(Type type/*,int? foreignKey1, int? foreignKey2*/);
        public List<Type> Read();
        public bool Update(Type type);
        public bool Delete(int id);
        public Type Get(int id);
    }
}
