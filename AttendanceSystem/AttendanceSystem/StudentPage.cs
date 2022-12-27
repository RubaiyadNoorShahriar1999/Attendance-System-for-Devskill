using AttendanceSystem.Models;
using AttendanceSystem.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class StudentPage
    {
        public static void StudentOption(Student student)
        {
            Console.WriteLine("Wellcome to your Student Portal " + student.UserName);
            Console.WriteLine("Tasks:\n1. Give your Attendance\n2. View your attendance sheet");
            int choice = int.Parse(Console.ReadLine());

            if(choice == 1)
            {
                Student st = new Student();
                Course c = new Course();
                Attendance at = new Attendance();

                Console.WriteLine("Enter your Student ID: ");
                st.Id= int.Parse(Console.ReadLine());
                Console.Write("Enter the Course ID you want to give attendance: ");
                c.Id = int.Parse(Console.ReadLine());
                Console.Write("Write Present: ");
                at.Present = Console.ReadLine();
                at.Time = DateTime.Now;
                bool entity = new StudentServices().GiveAttendance(st, c, at);

                if(entity)
                {
                    Console.WriteLine("Successfully Added your attedance to the list");
                }
                else
                {
                    Console.WriteLine("There was an unwanted error. Please check your Course ID and Student ID");
                }

            }
            else if(choice == 2) 
            {
                Attendance at = new Attendance();
                Console.Write("Enter your Student ID: ");
                at.StudentId = int.Parse(Console.ReadLine());
                bool entity = new StudentServices().ShowAttendance(at);
            }
        }
    }
}
