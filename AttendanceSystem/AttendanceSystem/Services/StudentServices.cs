using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Tasks
{
    public class StudentServices : IBasicAction<Student>
    {
        private static readonly AttendanceSystemDbContext db = new AttendanceSystemDbContext();
        public Student Create(Student student/*, int? foreignKey1, int? foreignKey2*/)
        {
/*            student.AdminId = foreignKey1 != null ? foreignKey1: 1 ;
            student.TeacherId = foreignKey2;*/
            Student entity = db.Students.Add(student).Entity;
            db.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            /*AttendanceSystemDbContext attendanceSystemDbContext = new AttendanceSystemDbContext();
            Student student = attendanceSystemDbContext.Students.Where(x => x.Id == id).FirstOrDefault();
            attendanceSystemDbContext.Students.Remove(student);
            attendanceSystemDbContext.SaveChanges();
            return true;*/

            throw new NotImplementedException();
        }

        public Student Get(int id)
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
