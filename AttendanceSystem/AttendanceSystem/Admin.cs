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
        public int Id { get; set; }
        protected string name { get; set; }
        protected string userName { get; set; }
        protected string password { get; set; }

        public Admin()
        {
            AttendanceSystemDbContext system = new AttendanceSystemDbContext();
            Admin admin = new Admin();
            admin.name = "Rubaiyad";
            admin.userName = "rubaiyad007";
            admin.password = "asd@123";
            system.Add(admin);
            system.SaveChanges();

            Admin a1 = system.Admins.Where(x => x.userName == userName).FirstOrDefault();
            if(a1 != null)
            {
                Console.WriteLine("Menu:\n 1. Assign Course to a Teacher\n 2. Assign Course to a Student\n 3. Set class schedule for a course");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                    AddCourseToTeacher();
                else if (choice == 2)
                    AddCourseToStudent();
                else if (choice == 3)
                    AddCourse();
            }


        }

        public void AddCourse()
        {
            AttendanceSystemDbContext system = new AttendanceSystemDbContext();
            Course course = new Course();
            Console.Write("Enter Course name: ");
            course.courseName = Console.ReadLine();
            Console.Write("Enter Course Fee: ");
            course.fees = double.Parse(Console.ReadLine());
            Console.Write("Enter class date: ");
            course.ClassStartDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter class time (ex. Monday 8PM-11PM,Thursday 8PM-11PM): ");
            course.classTime = Console.ReadLine().Replace(@"\s","");
            Console.Write("Enter number of classes: ");
            course.noOfClasses = int.Parse(Console.ReadLine());
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
