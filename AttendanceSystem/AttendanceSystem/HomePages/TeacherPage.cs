using AttendanceSystem.Models;
using AttendanceSystem.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.HomePages
{
    public class TeacherPage
    {
        public static void TeacherOption(Teacher teacher)
        {
            while (true)
            {
                int i = 0;
                Console.WriteLine("\n\t\t\t\tWelcome to your Portal: " + teacher.Name);
                Console.Write("Services:\n1. See attendance list of all students\n2. See attendance of students course wise\n3. See attendance of students Student ID wise\n4. View my courses\n5. Update profile\n6. Logout\nEnter option: ");
                int choice = int.Parse(Console.ReadLine().Replace(@"\s", ""));

                if (choice == 1)
                {
                    Attendance attendance = new Attendance();
                    Course course = new Course();
                    int ID = teacher.Id;
                    new TeacherServices().ShowAttendanceOfAllStudents(attendance,ID);
                }
                else if (choice == 2)
                {
                    Attendance attendance = new Attendance();
                    Console.Write("Enter Course ID: ");
                    attendance.CourseId = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                    bool entity = new TeacherServices().ShowAttendanceByCourse(attendance);
                    if (!entity)
                    {
                        Console.WriteLine("Sorry there is no reccord of the course");
                    }
                }
                else if (choice == 3)
                {
                    Attendance attendance = new Attendance();
                    Console.Write("Enter Student ID: ");
                    attendance.StudentId = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                    bool entity = new TeacherServices().ShowAttendanceByStudentID(attendance,teacher);
                    if(!entity)
                    {
                        Console.WriteLine("Sorry there is no reccord of the student");
                    }
                }
                else if (choice == 4)
                {
                    Course course = new Course();
                    Console.Write("Please re-enter your Teacher ID: ");
                    course.TeacherId = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                    bool c = new TeacherServices().ViewCourses(course);
                }
                else if(choice == 5)
                {
                    Teacher teacher1 = new Teacher();
                    teacher1.Id = teacher.Id;
                    teacher1.UserName = teacher.UserName;
                    teacher1.Password = teacher.Password;
                    if (i == 0)
                    {
                        bool entity = new TeacherServices().Update(teacher1);
                        if (entity)
                        {
                            i++;
                            Console.WriteLine("Successfully Updated");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You need to re-login for further update.");
                    }
                }
                else if (choice == 6)
                {
                    break;
                }
                else
                    Console.WriteLine("Enter a valid choice");
            }
        }

    }
}
