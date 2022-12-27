using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Tasks
{
    public class AdminServices: IBasicAction<Admin>
    {
        private static readonly AttendanceSystemDbContext db = new AttendanceSystemDbContext();
        public Admin Create(Admin type/*, int? foreignKey1, int? foreignKey2*/)
        {
            throw new NotImplementedException();
        }

        public List<Admin> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(Admin type)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Admin Get(int id)
        {
            throw new NotImplementedException();
        }

        public Schedule AssignClassSchedule(Schedule schedule)
        {
            Schedule entity = db.Schedules.Add(schedule).Entity;
            db.SaveChanges();
            return entity;
        }

/*        public bool AssignCourseToStudent(Course course, Student student)
        {
            course.CourseStudents.Add(new CourseStudent
            {
                StudentId = student.Id,
                CourseId = course.Id
            });

            new StudentServices().Update(student);

            return db.SaveChanges() > 0;
        }*/

        /*
                public bool AssignCourseToTeacher(Course course, Teacher teacher)
                {
                    course.TeacherId = teacher.Id;
                    return new CourseServices().Update(course);
                }

                public bool AssignTeacher(Student student, Teacher teacher)
                {
                    student.TeacherId = teacher.Id;
                    return new StudentServices().Create(student);
                }*/
    }
}
