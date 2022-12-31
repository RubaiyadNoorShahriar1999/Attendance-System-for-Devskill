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

        public bool UpdateProfile(Student type)
        {
            Student student = db.Students.Where(x => x.Id == type.Id).FirstOrDefault();
            if (student != null)
            {
                Console.WriteLine("Update options: 1. Update username 2. Update password");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                if (choice == 1)
                {
                    Console.Write("\nEnter new username: ");
                    student.UserName = Console.ReadLine();
                    if (student.UserName == type.UserName)
                    {
                        Console.WriteLine("You're previous username was same. Please Enter a new username.");
                        return false;
                    }
                    else
                    {
                        return db.SaveChanges() > 0;
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("\nEnter your new password: ");
                    student.Password = Console.ReadLine();
                    if (student.Password == type.Password)
                    {
                        Console.WriteLine("You're previous password was same. Please Enter a new password.");
                        return false;
                    }
                    else
                    {
                        return db.SaveChanges() > 0;
                    }                        
                }
                else
                    return false;
            }
            else
            {
                Console.WriteLine("Student ID doesn't exist");
                return false;
            }
        }

        public void ViewCourseSchedule(Student student)
        {
            List<Schedule> schedules = db.Schedules.Where(x => x.StudentId == student.Id).ToList();
            foreach(Schedule schedule in schedules)
            {
                Console.WriteLine("Course ID: "+ schedule.CourseId + "  Class Time: "+ schedule.ClassTime);
            }

            if(schedules.Count == 0) 
            {
                Console.WriteLine("You are not enrolled in any course");
            }
        }
        public List<Student> GetStudentByTeacherId(int id)
        {
            return db.Students.Where(s => s.TeacherId == id).ToList();
        }

        public bool GiveAttendance(Student student,Course course,Attendance attendance)
        {
            Attendance attendance1 = new Attendance();
            attendance1.CourseId = course.Id;
            attendance1.StudentId = student.Id;
            attendance1.Present = attendance.Present;
            attendance1.Time = attendance.Time;
            db.Attendances.Add(attendance1);
            return db.SaveChanges() > 0;
        }

        public void ShowAttendanceAll(Attendance attendance)
        {
            List<Attendance> entity = db.Attendances.Where(x => x.StudentId == attendance.StudentId).ToList();
            foreach (Attendance at in entity)
            {
                Console.Write("Student ID: " + at.StudentId + " Course ID: " + at.CourseId + " Time: " + at.Time);
                if (at.Present.ToLower() == "present")
                {
                    Console.WriteLine(" Present: " + ((char)0x221A).ToString() + "\n");
                }
                else
                {
                    Console.WriteLine(" Present: x\n");
                }
            }
            if (entity.Count == 0)
            {
                Console.WriteLine("You don't have any attendance record");
            }
        }

        public void ShowAllAttendanceOfCourse(Attendance attendance)
        {
            List<Attendance> entity = db.Attendances.Where(y => y.StudentId == attendance.StudentId).ToList();

            Course course = db.Courses.Where(x => x.Id == attendance.CourseId).FirstOrDefault();
            Student student = db.Students.Where(x => x.Id == attendance.StudentId).FirstOrDefault();
            foreach (Attendance at in entity)
            {
                if (at.CourseId == attendance.CourseId)
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
            }
            if(entity.Count == 0)
            {
                Console.WriteLine("You don't have any attendance record");
            }           
        }
    }
    }

