using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class Admin : User 
    {
        private string Name { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        public Admin(string name, string userName,string password) 
        {
            this.Name = name;
            this.UserName = userName;
            this.Password = password;

            Console.WriteLine("Menu:\n 1. Assign Course to a Teacher\n 2.Assign Course to a Student\n 3. Set class schedule for a course");
            int choice = Convert.ToInt32(Console.ReadLine());
        }
        
    }
}
