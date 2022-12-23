using AttendanceSystem;

Console.WriteLine("Log in as a:\n1. Admin\n2. Teacher\n3. Student");
int choice = Convert.ToInt32(Console.ReadLine());

List<Admin> admins = new List<Admin>();

Console.WriteLine("Enter Name: ");
string name = Console.ReadLine();
Console.WriteLine("Enter User Name: ");
string userName = Console.ReadLine();
Console.WriteLine("Enter Password: ");
string password = Console.ReadLine();

if (choice == 1)
        new Admin();
    else if (choice == 2)
        new Teacher();
    else if (choice == 3)
        new Student();
    else
        throw new Exception("Input is Invalid");

/*if (name != string.Empty && userName != string.Empty && password != string.Empty)
{
}*/
