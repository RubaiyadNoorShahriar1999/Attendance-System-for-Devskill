using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using OfficeOpenXml.ConditionalFormatting;
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
        public Student Create(Student student)
        {
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

        public bool GiveAttendance(Student student,Course course,Attendance attendance)
        {
            Attendance obj = new Attendance();
            obj.CourseId = course.Id;
            obj.StudentId = student.Id;
            obj.Present = attendance.Present;
            obj.Time = attendance.Time;
            db.Attendances.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool ShowAttendanceAll(Attendance attendance)
        {
            List<Attendance> entity = db.Attendances.Where(x => x.StudentId == attendance.StudentId).ToList();
            foreach(Attendance at in entity)
            {
                Console.Write("Student ID: "+at.StudentId +" Course ID: " + at.CourseId +" Time: "+at.Time );
                if (at.Present.ToLower() == "present")
                {
                    Console.WriteLine(" Present: " + ((char)0x221A).ToString() + "\n");
                }
                else 
                {
                    Console.WriteLine(" Present: x\n");
                }
            }
            return true;
        }

        public bool ShowAllAttendanceOfCourse(Attendance attendance)
        {
            List<Attendance> entity = db.Attendances.Where(y => y.CourseId == attendance.CourseId).ToList();
            Course course = db.Courses.Where(x => x.Id == attendance.CourseId).FirstOrDefault();
            Student student = db.Students.Where(x => x.Id == attendance.StudentId).FirstOrDefault();
            foreach (Attendance at in entity)
            {
                Console.Write("Student ID: " + student.Id + " Course ID: " + course.Id + " Time: " + at.Time);
                if (at.Present.ToLower() == "present")
                {
                    Console.WriteLine(" Present: " + ((char)0x221A).ToString() + "\n");
                }
                else
                {
                    Console.WriteLine(" Present: x\n");
                }
            }
            return true;
        }
    }
    }

