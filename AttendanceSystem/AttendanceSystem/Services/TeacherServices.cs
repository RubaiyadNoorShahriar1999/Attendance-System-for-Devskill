using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
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

        public void ShowAttendanceOfAllStudents(Attendance attendance, int ID)
        {
            List<Course> courses = db.Courses.ToList();
            foreach(Course x in courses)
            {
                if(x.TeacherId == ID)
                {
                    List<Attendance> attendances = db.Attendances.Where(c => c.CourseId == x.Id).ToList();
                    foreach (Attendance a in attendances)
                    {
                        Course course = db.Courses.Where(x => x.Id == a.CourseId).FirstOrDefault();
                        Student student = db.Students.Where(x => x.Id == a.StudentId).FirstOrDefault();
                        Console.Write("Student Name: " + student.Name + " Course Name: " + course.CourseName);
                        if (a.Present.ToLower() == "present")
                        {
                            Console.Write(" Present: " + ((char)0x221A).ToString() + " ");
                        }
                        else
                        {
                            Console.Write(" Present: x ");
                        }
                        Console.WriteLine("Time of attendance: " + a.Time);
                    }
                }
            }
        }
        public bool ShowAttendanceByCourse(Attendance attendance)
        {
            List<Attendance> attendances = db.Attendances.Where(x => x.CourseId ==  attendance.CourseId).ToList();
            foreach (Attendance a in attendances)
            {
                    Course course = db.Courses.Where(x => x.Id == a.CourseId).FirstOrDefault();
                    Student student = db.Students.Where(x => x.Id == a.StudentId).FirstOrDefault();
                    Console.Write("Course Name: " + course.CourseName + " Student Name: " + student.Name);
                    if (a.Present.ToLower() == "present")
                    {
                        Console.Write(" Present: " + ((char)0x221A).ToString() + " ");
                    }
                    else
                    {
                        Console.Write(" Present: x ");
                    }
                    Console.WriteLine("Time of attendance: " + a.Time);
            }
            if (attendances.Count == 0)
            {
                return false;
            }
            else
                return true;
        }

        public bool ShowAttendanceByStudentID(Attendance attendance, Teacher teacher)
        {
            int count = 0;
            List <Course> courses = db.Courses.Where(x => x.TeacherId == teacher.Id).ToList();
            foreach (Course course in courses)
            {
                List<Attendance> attendances = db.Attendances.Where(x => x.CourseId == course.Id).ToList();
                foreach (Attendance at in attendances)
                {
                    if(at.StudentId == attendance.StudentId)
                    {
                        Student student= db.Students.Where(x => x.Id == attendance.StudentId).FirstOrDefault();
                        Console.Write("Student Name: " + student.Name + " Course Name: " + course.CourseName);
                        if (at.Present.ToLower() == "present")
                        {
                            Console.Write(" Present: " + ((char)0x221A).ToString() + " ");
                        }
                        else
                        {
                            Console.Write(" Present: x ");
                        }
                        Console.WriteLine("Time of attendance: " + at.Time);
                        count++;
                    }
                }
            }
            if(count == 0)
            {
                return false;
            }
            else
                return true;
        }

        public bool ViewCourses(Course course)
        {
            List<Course> courses = db.Courses.Where(x => x.TeacherId== course.TeacherId).ToList();
            foreach (Course a in courses)
            {
                Console.WriteLine("Course name: " + a.CourseName + " Course ID: "+a.Id);
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
