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
        public Teacher Create(Teacher teacher)
        {
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

        public bool ShowAttendanceOfAStudents(Attendance attendance)
        {
            Attendance attendances = db.Attendances.Where( x => x.StudentId == attendance.StudentId).FirstOrDefault();
            Course course = db.Courses.Where(x => x.Id == attendance.CourseId).FirstOrDefault();
            Student student = db.Students.Where(x => x.Id == attendance.StudentId).FirstOrDefault();
        
            Console.Write("Student Name: "+ student.Name + " Course Name: "+ course.CourseName);
            if (attendances.Present == " Present")
            {
                Console.WriteLine(" Present: " + ((char)0x221A).ToString());
            }
            
            return true;
        }
        public bool ShowAttendanceOfAllStudents(Attendance attendance)
        {
            List<Attendance> attendances = db.Attendances.Where(x => x.StudentId == attendance.StudentId).ToList();
            Course course = db.Courses.Where(x => x.Id == attendance.CourseId).FirstOrDefault();
            Student student = db.Students.Where(x => x.Id == attendance.StudentId).FirstOrDefault();
            foreach (Attendance a in attendances)
            {
                Console.Write("Student Name: " + student.Name + " Course Name: " + course.CourseName);
                if (a.Present == "Present")
                {
                    Console.WriteLine(" Present: " + ((char)0x221A).ToString());
                }
            }
            return true;
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
