using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Tasks
{
    public class TeacherServices : IBasicAction<Teacher>
    {
        private static readonly AttendanceSystemDbContext db = new AttendanceSystemDbContext();
        public Teacher Create(Teacher teacher/*, int? foreignKey1, int? foreignKey2*/)
        {
/*            teacher.AdminId = foreignKey1;*/
            Teacher entity = db.Teachers.Add(teacher).Entity;
            db.SaveChanges();
            return entity;
        }
        public bool Delete(int id)
        {
            /*AttendanceSystemDbContext attendanceSystemDbContext = new AttendanceSystemDbContext();
            Teacher teacher = attendanceSystemDbContext.Teachers.Where(t => t.Id == id).FirstOrDefault();
            attendanceSystemDbContext.Teachers.Remove(teacher);
            attendanceSystemDbContext.SaveChanges();
            return true;*/

            throw new NotImplementedException();
        }

        public Teacher Get(int id)
        {
            return db.Teachers.Find(id);
        }

        public List<Teacher> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(Teacher type)
        {
            throw new NotImplementedException();
        }
    }
}
