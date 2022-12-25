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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            /*AttendanceSystemDbContext attendanceSystemDbContext= new AttendanceSystemDbContext();
            Course course = attendanceSystemDbContext.Courses.Where(x => x.Id == id).FirstOrDefault();
            attendanceSystemDbContext.Courses.Remove(course);
            attendanceSystemDbContext.SaveChanges();
            return true;*/

            throw new NotImplementedException();

        }

        public Course Get(int id)
        {
            throw new NotImplementedException();
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
