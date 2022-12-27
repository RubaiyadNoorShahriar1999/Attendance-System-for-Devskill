using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
            Teacher teacher = db.Teachers.Where(t => t.Id == id).FirstOrDefault();

            if(teacher == null) return false;

            db.Teachers.Remove(teacher);

            return db.SaveChanges() > 0;
        }

        public Teacher Get(int id)
        {
            return db.Teachers.Find(id);
        }

        public List<Teacher> Read()
        {
            return db.Teachers.ToList();
        }

        public bool Update(Teacher type)
        {
            throw new NotImplementedException();
        }
    }
}
