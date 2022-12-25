using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Tasks
{
    public class StudentTasks : IBasicAction<Student>
    {
        public bool Create(Student type)
        {
            AttendanceSystemDbContext db = new AttendanceSystemDbContext();
            Student student = new Student();
            Console.Write("Enter Course name: ");
            student.Name = Console.ReadLine();
            Console.Write("Enter Course Fee: ");
            student.UserName = Console.ReadLine();
            Console.Write("Enter class date: ");
            student.Password = Console.ReadLine();
            Console.Write("Enter class time (ex. Monday 8PM-11PM,Thursday 8PM-11PM): ");
            student.Schedule = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter number of classes: ");
            student.NoOfClasses = int.Parse(Console.ReadLine());
            db.Add(student);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            AttendanceSystemDbContext attendanceSystemDbContext = new AttendanceSystemDbContext();
            Student student = attendanceSystemDbContext.Students.Where(x => x.Id == id).FirstOrDefault();
            attendanceSystemDbContext.Students.Remove(student);
            attendanceSystemDbContext.SaveChanges();
            return true;
        }

        public List<Student> Read()
        {
            throw new NotImplementedException();
        }

        public bool Update(Student type)
        {
            throw new NotImplementedException();
        }
    }
}
