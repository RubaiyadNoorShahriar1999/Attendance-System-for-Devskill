using AttendanceSystem;


Console.WriteLine("Log in as a:\n1. Admin\n2. Teacher\n3. Student");
int choice = Convert.ToInt32(Console.ReadLine());
string name = Console.ReadLine();
string userName = Console.ReadLine();
string password = Console.ReadLine();
        Admin ad = new Admin(name, userName, password);

if(name != string.Empty && userName != string.Empty && password != string.Empty)
{
   /* if (choice == 1)*/
    /*else if (choice == 2)
        new Teacher();
    else if (choice == 3)
        new Student();
    else
        throw new Exception("Input is Invalid");*/

}
