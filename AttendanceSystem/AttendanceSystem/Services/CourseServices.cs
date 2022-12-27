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
        public Course Create(Course course/*, int? foreignKey1, int? foreignKey2*/)
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

        public Course Get(int id)
        {
           return db.Courses.Find(id);
        }

        public List<Course> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(Course type)
        {
            /*AttendanceSystemDbContext attendanceSystemDbContext = new AttendanceSystemDbContext();
            Course course = attendanceSystemDbContext.Courses.Where(x => x.Id == type.TeacherId).FirstOrDefault();
            course.TeacherId = type.TeacherId;
            return attendanceSystemDbContext.SaveChanges() > 0;*/

            throw new NotImplementedException();
        }
    }
}
