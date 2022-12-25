using AttendanceSystem.Models;
using AttendanceSystem.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class AdminPage
    {
        private static readonly AttendanceSystemDbContext db = new AttendanceSystemDbContext();
        public static void AdminOption(Admin admin)
        {

            Console.WriteLine("Task:\n1. Create a Teacher\n2. Create a Student\n3. Add a Course\n4. Assign a course to a teacher\n5. Assign a course to a student\n6. Set class schedule for a course");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                // Take input form user and assign to teacher
                Teacher teacher = new Teacher();
                Console.Write("Enter Teacher name: ");
                teacher.Name = Console.ReadLine();
                Console.Write("Enter User name: ");
                teacher.UserName = Console.ReadLine();
                Console.Write("Enter Password: ");
                teacher.Password = Console.ReadLine();
                Console.Write("Enter class time (ex. Monday 8PM-11PM,Thursday 8PM-11PM): ");
                teacher.Schedule = Console.ReadLine().Replace(@"\s", "");
                Console.Write("Enter number of classes: ");
                teacher.NoOfClasses = int.Parse(Console.ReadLine());
                teacher.AdminId = admin.Id;
                Teacher entity = new TeacherServices().Create(teacher/*,admin.Id,null*/);
                if (entity != null)
                {
                    Console.WriteLine("Success");
                    Console.WriteLine("Teacher ID: " + entity.Id.ToString());
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }else if(choice == 2)
            {
                Student student = new Student();
                Console.Write("Enter Student name: ");
                student.Name = Console.ReadLine();
                Console.Write("Enter User name: ");
                student.UserName = Console.ReadLine();
                Console.Write("Enter password: ");
                student.Password = Console.ReadLine();
                Console.Write("Enter class time (ex. Monday 8PM-11PM,Thursday 8PM-11PM): ");
                student.Schedule = Console.ReadLine().Replace(@"\s", "");
                Console.Write("Enter number of classes: ");
                student.NoOfClasses = int.Parse(Console.ReadLine());
                student.AdminId = admin.Id;
                Console.Write("Enter Teacher ID: ");
                int teacherfk = int.Parse(Console.ReadLine());
                Teacher isTeacherExist = new TeacherServices().Get(teacherfk);
                if(isTeacherExist == null)
                {
                    Console.WriteLine("Teacher does not exist");
                    return;
                }
                student.TeacherId = teacherfk;
                Student entity = new StudentServices().Create(student/*, admin.Id*/);
                if (entity != null)
                {
                    Console.WriteLine("Success");
                    Console.WriteLine("Student ID: " + entity.Id.ToString());
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
/*            else if (choice == 5)
            {
                // take course id and student id from user
                // check if the id exists in the database
            }*/
        }
    }
}
