using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
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
            Student? student = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (student != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
                return true;
            }
            else
            {
                Console.WriteLine("Student does not exist");
                return false;
            }
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public List<Student> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(Student type)
        {
            var student = db.Students.Where(s => s.Id == type.Id).SingleOrDefault();

            if (student == null)
            {
                return false;
            }

            db.Entry(student).CurrentValues.SetValues(type);

            return db.SaveChanges() > 0;
        }

        public List<Student> GetStudentByTeacherId(int id)
        {
            return db.Students.Where(s => s.TeacherId == id).ToList();
        }
    }
}
