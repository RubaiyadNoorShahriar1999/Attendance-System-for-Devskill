using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AttendanceSystem
{
    public class Admin : AddCourse 
    {
        protected int Id { get; set; }
        private string name { get; set; }
        private string userName { get; set; }
        private string password { get; set; }

        public Admin(string name, string userName, string password)
        {
            this.name = name;
            this.userName = userName;
            this.password = password;

            Console.WriteLine("Menu:\n 1. Assign Course to a Teacher\n 2. Assign Course to a Student\n 3. Set class schedule for a course");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
                AddCourseToTeacher();
            else if (choice == 2)
                AddCourseToStudent();
            else if (choice == 3)
                AddCourse();
        }

        public void AddCourse()
        {
            AttendanceSystemDbContext system = new AttendanceSystemDbContext();
            Course course = new Course();
            Console.Write("Enter Course name: ");
            course.courseName = Console.ReadLine();
            Console.Write("Enter Course Fee: ");
            course.fees = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter class date: ");
            course.ClassStartDate = DateTime.Parse(Console.ReadLine());
            system.Add(course);
            system.SaveChanges();
        }
        public void AddCourseToTeacher()
        {
            int courseID,fees;
            string courseName;
            DateTime schedule;
            courseName = Console.ReadLine();
            courseID = Convert.ToInt32(Console.ReadLine());
            schedule = DateTime.Parse(Console.ReadLine());
        }
        public void AddCourseToStudent()
        {
            int courseID, fees;
            string courseName;
            DateTime schedule;
            courseName = Console.ReadLine();
            courseID = Convert.ToInt32(Console.ReadLine());
            schedule = DateTime.Parse(Console.ReadLine());
        }


    }
}
