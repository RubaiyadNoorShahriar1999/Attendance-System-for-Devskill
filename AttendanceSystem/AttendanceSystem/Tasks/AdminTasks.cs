using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Tasks
{
    public class AdminTasks: IBasicAction<Admin>
    {
        public bool Create(Admin type)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
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

        public bool AddCourse(Course course)
        {
            return new CourseTasks().Create(course);
        }

        public bool AssignTeacher(Student student, Teacher teacher)
        {
            student.TeacherId = teacher.Id;
            return new StudentTasks().Create(student);
        }
    }
}
