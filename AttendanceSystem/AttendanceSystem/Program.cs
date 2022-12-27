﻿using AttendanceSystem;
using AttendanceSystem.Models;
using AttendanceSystem.Tasks;

AttendanceSystemDbContext ad = new AttendanceSystemDbContext();

Console.WriteLine("Log in as a:\n1.Admin 2.Teacher 3.Student");
int choice = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter User Name: ");
string userName = Console.ReadLine();
Console.Write("Enter Password: ");
string password = Console.ReadLine();

int count = 100;
while(count > 0)
{
    if (userName != string.Empty && password != string.Empty)
    {
        if (choice == 1)
        {
            Admin a1 = ad.Admins.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (a1 != null)
                AdminPage.AdminOption(a1);
        }
        else if (choice == 2)
        {
            Teacher t1 = ad.Teachers.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (t1 != null)
                TeacherPage.TeacherOption(t1);
        }
        else if (choice == 3)
        {
            Student s1 = ad.Students.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (s1 != null)
                StudentPage.StudentOption(s1);
        }
        else
            Console.WriteLine("Invalid Input");
    }
}

