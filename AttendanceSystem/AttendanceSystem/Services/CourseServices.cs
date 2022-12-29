using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Tasks
{
    public class CourseServices : IBasicAction<Course>
    {
    private static readonly AttendanceSystemDbContext db = new AttendanceSystemDbContext();
        public Course Create(Course course)
        {
            Course entity = db.Courses.Add(course).Entity;
            db.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        { 
            Course course = db.Courses.Where(x => x.Id == id).FirstOrDefault();
            if(course != null )
            {
                db.Courses.Remove(course);
                db.SaveChanges();
                return true;
            }
            else
            {
                Console.WriteLine("Course does not exist");
                return false;
            }
        }
        public List<Course> GetCourseByTeacherId(int id)
        {
            return db.Courses.Where(s => s.TeacherId == id).ToList();
        }


        public Course Get(int id)
        {
           return db.Courses.Find(id);
        }

        public bool CheckIfExist(Student student,Course course)
        {
            int i = 0;
            List<CourseStudent> cs = db.CourseStudents.Where(x => x.CourseId == course.Id).ToList();
            foreach (CourseStudent c in cs)
            {
                if (c.StudentId == student.Id)
                    i++;
            }
            if(i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

   /*     public bool IsCourseValid(Course course)
        {
            bool isTrue = false;
            List<Course> courses = db.Courses.ToList();
            foreach(Course x in courses)
            {
                if(x.Id== course.Id)
                {
                    TimeSpan courseEndCheck = DateTime.Now.Subtract(x.ClassEndDate);
                    TimeSpan courseStartCheck = x.ClassStartDate.Subtract(DateTime.Now);

                    if (courseStartCheck.Hours > 0)
                    {
                        Console.WriteLine("Sorry the course hasn't started yet. Try giving attendance after the course starts.");
                        isTrue = false;
                        break;
                        
                    }
                    else if (courseEndCheck.Hours > 0 || courseEndCheck.Hours == 0)
                    {
                        Console.WriteLine("Sorry the course has already ended. You can not give attendance.");
                        isTrue = false;
                        break;
                    }
                    else
                    {
                        isTrue= true;
                    }
                }
            }
            return isTrue;

        }*/
        public bool IsDuplicate(Student student, Course course)
        {
            bool isDuplicate = false;   
            List<Attendance> attendances = db.Attendances.ToList();
            foreach(Attendance att in attendances)
            {
                TimeSpan difference = att.Time.Subtract(DateTime.Now);
                if(att.CourseId == course.Id && att.StudentId == student.Id && difference.Hours < 24)
                {
                    isDuplicate = true;
                    break;
                }
                else
                {
                    isDuplicate = false;
                }
            }
            if(isDuplicate)
            { return true; }
            else
            { return false; }
        }

        public List<Course> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(Course type)
        {
            throw new NotImplementedException();
        }
    }
}
