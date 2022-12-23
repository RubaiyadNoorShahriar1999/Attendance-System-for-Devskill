using AttendanceSystem.Interfaces;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Tasks
{
    public class CourseTasks : IBasicAction<Course>
    {
        public bool Create(Course type)
        {
            AttendanceSystemDbContext db = new AttendanceSystemDbContext();
            Course course = new Course();
            Console.Write("Enter Course name: ");
            course.CourseName = Console.ReadLine();
            Console.Write("Enter Course Fee: ");
            course.Fees = double.Parse(Console.ReadLine());
            Console.Write("Enter class date: ");
            course.ClassStartDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter class time (ex. Monday 8PM-11PM,Thursday 8PM-11PM): ");
            course.ClassTime = Console.ReadLine().Replace(@"\s", "");
            Console.Write("Enter number of classes: ");
            course.NoOfClasses = int.Parse(Console.ReadLine());
            db.Add(course);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
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
