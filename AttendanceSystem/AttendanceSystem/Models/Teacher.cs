using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Models
{
    public class Teacher
    {
        [Key("Id")]
        public int Id { get; set; } 
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
/*        public string Schedule { get; set; }*/
/*        public int NoOfClasses { get; set; }*/

        [ForeignKey("AdminId")]
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
