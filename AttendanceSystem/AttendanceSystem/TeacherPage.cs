using AttendanceSystem.Models;
using AttendanceSystem.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class TeacherPage
    {
        public static void TeacherOption(Teacher teacher)
        {
            Console.WriteLine("Welcome to your Portal: " + teacher.Name);
            Console.WriteLine("Tasks:\n1. See attendance list of all students\n2. See attendance of spacific student");
            int choice = int.Parse(Console.ReadLine());

            if(choice == 1)
            {
                Attendance attendance = new Attendance();
                Console.Write("Enter Student ID: ");
                attendance.StudentId = int.Parse(Console.ReadLine());
                Console.Write("Enter Course ID: ");
                attendance.CourseId = int.Parse(Console.ReadLine());
                bool entity = new TeacherServices().ShowAttendanceOfAllStudents(attendance);
            }
            else if(choice == 2)
            {
                Attendance attendance = new Attendance();
                Console.Write("Enter Student ID: ");
                attendance.StudentId = int.Parse(Console.ReadLine());
                Console.Write("Enter Course ID: ");
                attendance.CourseId = int.Parse(Console.ReadLine());
                bool entity = new TeacherServices().ShowAttendanceOfAStudents(attendance);
            }
        }

    }
}
