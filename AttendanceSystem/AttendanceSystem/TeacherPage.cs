﻿using AttendanceSystem.Models;
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
            Console.WriteLine("\n\t\t\t\tWelcome to your Portal: " + teacher.Name);
            Console.WriteLine("Services:\n1. See attendance list of all students\n2. See attendance of spacific student (Not Complete)");
            Console.Write("Enter a service number: ");
            int choice = int.Parse(Console.ReadLine());

            if(choice == 1)
            {
                Attendance attendance = new Attendance();
                bool entity = new TeacherServices().ShowAttendanceOfAllStudents(attendance);
            }
            else if(choice == 2)
            {
                /*                Attendance attendance = new Attendance();
                                Console.Write("Enter Student ID: ");
                                attendance.StudentId = int.Parse(Console.ReadLine());
                                Console.Write("Enter Course ID: ");
                                attendance.CourseId = int.Parse(Console.ReadLine());
                                bool entity = new TeacherServices().ShowAttendanceOfAStudents(attendance);*/
                Console.WriteLine("This feature is not yet complete. Please try again later");
            }
            else
                Console.WriteLine("Enter a valid choice");
        }

    }
}
