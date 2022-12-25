using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Tasks
{
    public class TeacherTasks : IBasicAction<Teacher>
    {
        public bool Create(Teacher type)
        {
            AttendanceSystemDbContext db = new AttendanceSystemDbContext();
            Teacher teacher = new Teacher();
            Console.Write("Enter Course name: ");
            teacher.Name = Console.ReadLine();
            Console.Write("Enter Course Fee: ");
            teacher.UserName = Console.ReadLine();
            Console.Write("Enter class date: ");
            teacher.Password = Console.ReadLine();
            Console.Write("Enter class time (ex. Monday 8PM-11PM,Thursday 8PM-11PM): ");
            teacher.Schedule = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter number of classes: ");
            teacher.NoOfClasses = int.Parse(Console.ReadLine());
            db.Add(teacher);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            AttendanceSystemDbContext attendanceSystemDbContext = new AttendanceSystemDbContext();
            Teacher teacher = attendanceSystemDbContext.Teachers.Where(t => t.Id == id).FirstOrDefault();
            attendanceSystemDbContext.Teachers.Remove(teacher);
            attendanceSystemDbContext.SaveChanges();
            return true;
        }

        public List<Teacher> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(Teacher type)
        {
            throw new NotImplementedException();
        }
    }
}
