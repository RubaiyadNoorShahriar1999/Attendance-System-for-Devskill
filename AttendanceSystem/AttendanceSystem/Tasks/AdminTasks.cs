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
            Console.WriteLine("Task:\n 1. Create a Teacher\n2. Create a Student\n3. Add a Course\n4. Assign a course to a teacher\n5. Assign a course to a student\n6. Set class schedule for a course");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Teacher teacher = new Teacher();
                return new TeacherTasks().Create(teacher);
            }else if(choice == 2)
            {
                Student student = new Student();
                return new StudentTasks().Create(student);
            }else if(choice == 3)
            {
                Course course = new Course();
                return new CourseTasks().Create(course);
            }else if(choice == 4)
            {

            }
            return true;
        }
/*
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
        }*/

        public bool AssignCourseToTeacher(Course course, Teacher teacher)
        {
            course.TeacherId = teacher.Id;
            return new CourseTasks().Update(course);
        }
        public bool AssignCourseToStudent(Course course, Student student)
        {
            course.CourseStudents = student.StudentCourses;
            return new CourseTasks().Update(course);
        }
        public bool AssignTeacher(Student student, Teacher teacher)
        {
            student.TeacherId = teacher.Id;
            return new StudentTasks().Create(student);
        }
    }
}
