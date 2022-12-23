using AttendanceSystem;
using AttendanceSystem.Models;

AttendanceSystemDbContext ad = new AttendanceSystemDbContext();
/*Admin xD = new Admin();
xD.Name = "Rubaiyad";
xD.UserName = "rubaiyad007";
xD.Password = "asd@123";
ad.Add(xD);
ad.SaveChanges();
*/

Console.WriteLine("Log in as a:\n1. Admin\n2. Teacher\n3. Student");
int choice = Convert.ToInt32(Console.ReadLine());

/*List<Admin> admins = new List<Admin>();*/

Console.Write("Enter Name: ");
string name = Console.ReadLine();
Console.Write("Enter User Name: ");
string userName = Console.ReadLine();
Console.Write("Enter Password: ");
string password = Console.ReadLine();

Admin a1 = ad.Admins.Where(x => x.UserName == userName).FirstOrDefault();

if (name != string.Empty && userName != string.Empty && password != string.Empty)
{
    if (choice == 1 && a1 != null)
        new Admin();
    else if (choice == 2)
        new Teacher();
    else if (choice == 3)
        new Student();
    else
        Console.WriteLine("Invalid Input");
}
