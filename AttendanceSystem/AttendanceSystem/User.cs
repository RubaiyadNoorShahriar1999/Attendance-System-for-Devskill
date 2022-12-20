using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class User
    {
        protected int choice;
        protected string Name { get; set; }
        protected string UserName { get; set; }
        protected string Password { get; set; }

        public User(int choice,string name, string userName, string password) 
        {
            this.choice = choice;
            this.Name = name;
            this.UserName = userName;
            this.Password = password;
/*            if (choice == 1)
                new Admin(name, userName, password);
            else if (choice == 2)
                new Teacher();
            else if (choice == 3)
                new Student();
            else
                throw new Exception("Input is Invalid");*/
        }

    }
}
