using AttendanceSystem;
using AttendanceSystem.HomePages;
using AttendanceSystem.Models;
using AttendanceSystem.Tasks;

AttendanceSystemDbContext ad = new AttendanceSystemDbContext();
Console.WriteLine("\t\t\t\t\tWelcome to Attendance System for Dev Skill\n");
Console.WriteLine("Log in as a:  1. Admin  2. Teacher  3. Student");
Console.Write("Enter an option: ");
int choice = Convert.ToInt32(Console.ReadLine());

while(choice > 3)
{
    Console.WriteLine("Invalid choice!");
    Console.Write("Enter an option: ");
    choice = Convert.ToInt32(Console.ReadLine());
}

Console.Write("\nEnter User Name: ");
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
            else
                Console.WriteLine("Wrong Username and Password"); /*break;*/
        }
        else if (choice == 2)
        {
            Teacher t1 = ad.Teachers.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (t1 != null)
                TeacherPage.TeacherOption(t1);
            else
                Console.WriteLine("Wrong Username and Password"); break;
        }
        else if (choice == 3)
        {
            Student s1 = ad.Students.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (s1 != null)
                StudentPage.StudentOption(s1);
            else
                Console.WriteLine("Wrong Username and Password"); break;
        }          
    }
    else
    {
        Console.WriteLine("Input can not be empty. Please enter a valid Username & Password");
    }
}

