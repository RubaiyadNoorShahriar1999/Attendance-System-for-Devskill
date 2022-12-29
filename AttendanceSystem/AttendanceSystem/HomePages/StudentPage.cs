using AttendanceSystem.Models;
using AttendanceSystem.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.HomePages
{
    public class StudentPage
    {
        public static void StudentOption(Student student)
        {
            while(true)
            {

                Console.WriteLine("\n\t\t\t\tWelcome to your Student Portal " + student.Name);
                Console.Write("Services:\n1. Give your Attendance\n2. View your attendance sheet\n3. Logout\nEnter option: ");
                
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Student st = new Student();
                    Course c = new Course();
                    Attendance at = new Attendance();
                    st.Id = student.Id;
                    Console.Write("Enter the Course ID you want to give attendance: ");
                    c.Id = int.Parse(Console.ReadLine());
                    bool isExist = new CourseServices().CheckIfExist(st,c);
                    if (isExist)
                    {
                        bool isDuplicate = new CourseServices().IsDuplicate(st,c);
                        if (isDuplicate)
                        {
                            Console.WriteLine("You have already given your attendance");
                        }
                        else
                        {
                            Console.Write("Write Present (Caution: Anything other then \"Present\" may result in \"Not Presesnt\"): ");
                            at.Present = Console.ReadLine();
                            at.Time = DateTime.Now;
                            bool entity = new StudentServices().GiveAttendance(st, c, at);

                            if (entity)
                            {
                                Console.WriteLine("Successfully Added your attedance to the list");
                            }
                            else
                            {
                                Console.WriteLine("There was an unwanted error. Please check your Course ID and Student ID");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Student is not enrolled in this course");
                    }

                }
                else if (choice == 2)
                {
                    Console.WriteLine("\nChoose an option: 1. Attendance of all courses 2. Attendance of a particular course (Not complete)");
                    Console.Write("Enter your choice: ");
                    int choice1 = int.Parse(Console.ReadLine());
                    #region Duplication check

                    #endregion

                    if (choice1 == 1)
                    {
                        Attendance at1 = new Attendance();
                        Console.Write("Enter your Student ID: ");
                        at1.StudentId = int.Parse(Console.ReadLine());
                        new StudentServices().ShowAttendanceAll(at1);
                    }
                    else if (choice == 2)
                    {
                        Attendance at2 = new Attendance();
                        Console.Write("Enter your Student ID: ");
                        at2.StudentId = int.Parse(Console.ReadLine());
                        Console.Write("Enter your Course ID: ");
                        at2.CourseId = int.Parse(Console.ReadLine());
                        new StudentServices().ShowAllAttendanceOfCourse(at2);
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid choice");
                    }
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                    Console.WriteLine("Enter a valid choice");
            }
        }
    }
}
