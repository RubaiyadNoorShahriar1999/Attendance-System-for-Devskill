using AttendanceSystem.HomePages;
using AttendanceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class Bootstrap
    {
        private static readonly AttendanceSystemDbContext db = new AttendanceSystemDbContext();
        public static void ApplicationStart()
        {
            while (true)
            {
                int choice = 0;
                string userName = "";
                string password = "";

                Console.Write("Login Options: ");
                Console.Write("\n1. Admin Login\n2. Teacher Login\n3. Student Login\nEnter option: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.Write("Enter User Name: ");
                        userName = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        password = Console.ReadLine();

                        if (userName != string.Empty && password != string.Empty)
                        {
                            Admin a1 = Bootstrap.db.Admins.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
                            if (a1 != null)
                                AdminPage.AdminOption(a1);
                            else
                                Console.WriteLine("Wrong Username and Password");
                        }
                        else
                        {
                            Console.WriteLine("Input can not be empty. Please enter a valid Username & Password");
                        }

                        break;

                    case 2:
                        Console.WriteLine();
                        Console.Write("Enter User Name: ");
                        userName = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        password = Console.ReadLine();

                        if (userName != string.Empty && password != string.Empty)
                        {
                            Teacher a1 = Bootstrap.db.Teachers.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
                            if (a1 != null)
                                TeacherPage.TeacherOption(a1);
                            else
                                Console.WriteLine("Wrong Username and Password");
                        }
                        else
                        {
                            Console.WriteLine("Input can not be empty. Please enter a valid Username & Password");
                        }

                        break;

                    case 3:
                        Console.WriteLine();
                        Console.Write("Enter User Name: ");
                        userName = Console.ReadLine();
                        Console.Write("Enter Password: ");
                        password = Console.ReadLine();

                        if (userName != string.Empty && password != string.Empty)
                        {
                            Student s1 = Bootstrap.db.Students.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
                            if (s1 != null)
                                StudentPage.StudentOption(s1);
                            else
                                Console.WriteLine("Wrong Username and Password");
                        }
                        else
                        {
                            Console.WriteLine("Input can not be empty. Please enter a valid Username & Password");
                        }

                        break;

                    default:
                        Console.WriteLine("Invalid Input!!");
                        Console.WriteLine();
                        break;
                }
            }

        }
    }
}
