using AttendanceSystem;


Console.WriteLine("Log in as a:\n1. Admin\n2. Teacher\n3. Student");
int choice = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter Name: ");
string name = Console.ReadLine();
Console.WriteLine("Enter User Name: ");
string userName = Console.ReadLine();
Console.WriteLine("Enter Password: ");
string password = Console.ReadLine();


if (name != string.Empty && userName != string.Empty && password != string.Empty)
{
    if (choice == 1)
        new Admin(name, userName, password);
    else if (choice == 2)
        new Teacher(name, userName, password);
    else if (choice == 3)
        new Student(name, userName, password);
    else
        throw new Exception("Input is Invalid");
}
