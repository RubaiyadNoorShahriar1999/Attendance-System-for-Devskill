using AttendanceSystem.Models;
using AttendanceSystem.Tasks;
using OfficeOpenXml.ConditionalFormatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.HomePages
{
    public class AdminPage
    {
        private static readonly AttendanceSystemDbContext db = new AttendanceSystemDbContext();
        public static void AdminOption(Admin admin)
        {
            while(true)
            {
                Console.WriteLine("\n\t\t\t\tWelcome to the System Admin " + admin.Name);
                Console.Write("Services:\n1. Create/Delete a Teacher\n2. Create/Delete a Student\n3. Add/Remove a Course\n4. Assign a course to a student\n5. Set class schedule for a course\n6. Logout\nEnter option: ");

                int choice = int.Parse(Console.ReadLine().Replace(@"\s", ""));

                if (choice == 1)
                {
                    Console.WriteLine("Services:\n1. Add a Teacher 2. Delete a Teacher");
                    Console.Write("Enter service number: ");
                    int addOrDelete = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                    if (addOrDelete == 1)
                    {
                        Teacher teacher = new Teacher();
                        Console.Write("Enter Teacher name: ");
                        teacher.Name = Console.ReadLine().Replace(@"\s", "");
                        Console.Write("Enter User name: ");
                        teacher.UserName = Console.ReadLine().Replace(@"\s", "");
                        Console.Write("Enter Password: ");
                        teacher.Password = Console.ReadLine();
                        teacher.AdminId = admin.Id;
                        Teacher entity = new TeacherServices().Create(teacher);
                        if (entity != null)
                        {
                            Console.Write("Successfully added the teacher.");
                            Console.WriteLine("Teacher ID: " + entity.Id.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Failed");
                        }

                    }
                    else if (addOrDelete == 2)
                    {
                        Console.Write("Enter Teacher ID: ");
                        int tid = int.Parse(Console.ReadLine().Replace(@"\s", ""));

                        if (new TeacherServices().Get(tid) == null)
                        {
                            Console.WriteLine("Teacher doesn't exists");
                            return;
                        }

                        List<Student> students = new StudentServices().GetStudentByTeacherId(tid);

                        foreach (var student in students)
                        {
                            student.TeacherId = 1;
                            new StudentServices().Update(student);
                        }

                        List<Course> courses = new CourseServices().GetCourseByTeacherId(tid);

                        foreach (var course in courses)
                        {
                            course.TeacherId = 1;
                            new CourseServices().Update(course);
                        }

                        var isDeleted = new TeacherServices().Delete(tid);
                        if (isDeleted)
                        {
                            Console.WriteLine("Successfully deleted the teacher");
                        }
                        else
                        {
                            Console.WriteLine("Failed");
                        }
                    }
                    else
                        Console.WriteLine("Enter a valid choice");
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Services:\n1. Add a Student 2. Delete a Student");
                    Console.Write("Enter service number: ");
                    int addOrDelete = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                    if (addOrDelete == 1)
                    {
                        Student student = new Student();
                        Console.Write("Enter Student name: ");
                        student.Name = Console.ReadLine().Replace(@"\s", "");
                        Console.Write("Enter User name: ");
                        student.UserName = Console.ReadLine().Replace(@"\s", "");
                        Console.Write("Enter password: ");
                        student.Password = Console.ReadLine();
                        student.AdminId = admin.Id;
                        Console.Write("Enter Teacher ID: ");
                        int teacherfk = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                        Teacher isTeacherExist = new TeacherServices().Get(teacherfk);
                        if (isTeacherExist == null)
                        {
                            Console.WriteLine("Student does not exist");
                            return;
                        }
                        student.TeacherId = teacherfk;
                        Student entity = new StudentServices().Create(student);
                        if (entity != null)
                        {
                            Console.WriteLine("Successfully added student.");
                            Console.WriteLine("Student ID: " + entity.Id.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Failed");
                        }
                    }
                    else if (addOrDelete == 2)
                    {
                        Console.Write("Insert Student ID: ");
                        int ID = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                        Student student = new StudentServices().Get(ID);
                        if (student == null)
                            Console.WriteLine("Student does not exist");
                        else
                        {
                            if (student.TeacherId == null)
                            {
                                Console.Write("Enter a new Teacher ID: ");
                                int tID = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                                Teacher isTeacherExist = new TeacherServices().Get(tID);
                                if (isTeacherExist == null)
                                {
                                    Console.WriteLine("Teacher does not exist");
                                    return;
                                }
                                else
                                {
                                    student.TeacherId = tID;
                                }
                            }
                            bool entity = new StudentServices().Delete(ID);
                            if (entity != false)
                            {
                                Console.Write("Successfully deleted the student.");
                                Console.WriteLine("Student ID: " + ID + " successfully deleted");
                            }
                            else
                            {
                                Console.WriteLine("Failed");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid choice");
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Services:\n1. Add a Course 2. Delete a Course");
                    Console.Write("Enter service number: ");
                    int addOrDelete = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                    if (addOrDelete == 1)
                    {
                        Course course = new Course();
                        Console.Write("Enter Course name: ");
                        course.CourseName = Console.ReadLine().Replace(@"\s", "");
                        Console.Write("Enter course fees: ");
                        course.Fees = double.Parse(Console.ReadLine());
                        Console.Write("Enter class start date (ex. Month/Day/Year - 12/29/2022): ");
                        course.ClassStartDate = DateTime.Parse(Console.ReadLine());
                        /*                        Console.Write("Enter class End date (ex. Month/Day/Year - 12/29/2022): ");*/
                        /*                        course.ClassEndDate = DateTime.Parse(Console.ReadLine());*/
                        Console.Write("Enter class time (ex. Monday 8PM-11PM,Thursday 8PM-11PM): ");
                        course.ClassTime = Console.ReadLine().Replace(@"\s", "");
                        Console.Write("Enter number of classes: ");
                        course.NoOfClasses = int.Parse(Console.ReadLine());
/*                        course.CourseTotalDays = course.ClassStartDate.Subtract(course.ClassEndDate);*/
                        course.AdminId = admin.Id;
                        Console.Write("Enter Teacher ID (You need to assign a teacher to your created course): ");
                        int teacherfk = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                        Teacher isTeacherExist = new TeacherServices().Get(teacherfk);
                        if (isTeacherExist == null)
                        {
                            Console.WriteLine("Teacher does not exist");
                            return; 
                        }
                        else
                        {
                            course.TeacherId = teacherfk;
                        }

                        Course entity = new CourseServices().Create(course);
                        if (entity != null)
                        {
                            Console.WriteLine("Successfully added the course.");
                            Console.WriteLine("Course ID: " + entity.Id.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Failed");
                        }

                    }
                    else if (addOrDelete == 2)
                    {
                        Console.Write("Insert Course ID: ");
                        int ID = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                        Course course = new CourseServices().Get(ID);
                        if (course == null)
                            Console.WriteLine("Course does not exist");
                        else
                        {
                            bool entity = new CourseServices().Delete(ID);
                            if (entity != false)
                            {
                                Console.Write("Successfully deleted the course.");
                                Console.WriteLine("Course ID: " + ID + " successfully deleted");
                            }
                            else
                            {
                                Console.WriteLine("Failed");
                            }
                        }
                    }
                    else
                        Console.WriteLine("Enter a valid choice");
                }
                else if (choice == 4)
                {
                    Course course = new Course();
                    Student student = new Student();
                    CourseStudent courseStudent = new CourseStudent();
                    Console.Write("Enter Course ID: ");
                    int courseId = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                    Console.Write("Enter Student ID: ");
                    int studentId = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                    int i = 0;

                    List<CourseStudent> cs = db.CourseStudents.Where(x => x.CourseId == courseId).ToList();
                    foreach(CourseStudent c in cs)
                    {
                        if (c.StudentId == studentId)
                            i++;
                    }

                    #region Duplication checking

                    if (i == 0)
                    {
                        course = db.Courses.Where(y => y.Id == courseId).FirstOrDefault();
                        student = db.Students.Where(y => y.Id == studentId).FirstOrDefault();

                        if (course != null && student != null)
                        {
                            courseStudent.StudentId = studentId;
                            courseStudent.CourseId = courseId;
                            db.Add(courseStudent);
                            db.SaveChanges();
                            Console.WriteLine("Successfully assigned the course to Student ID " + studentId);
                        }
                        else
                        {
                            Console.WriteLine("Enter Valid ID");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The student is already enrolled in this course");
                    }
                    #endregion
                }
                else if (choice == 5)
                {
                    Schedule schedule = new Schedule();
                    Console.Write("Enter Course ID: ");
                    schedule.CourseId = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                    Console.Write("Enter Teacher ID: ");
                    schedule.TeacherId = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                    Console.Write("Enter Student ID: ");
                    schedule.StudentId = int.Parse(Console.ReadLine().Replace(@"\s", ""));
                    Console.Write("Enter number of classes: ");
                    schedule.NoOfClasses = int.Parse(Console.ReadLine());
                    Console.Write("Enter the class times (ex. Monday 8PM-11PM,Thursday 9PM-11PM): ");
                    schedule.ClassTime = Console.ReadLine().Replace(@"\s", "");

                    Schedule entity = new AdminServices().AssignClassSchedule(schedule);
                    if (entity != null)
                    {
                        Console.WriteLine("Successfully added a new schedule");
                    }
                    else
                    {
                        Console.WriteLine("Error! Unsuccessful submission");
                    }

                }
                else if (choice == 6)
                {
                    break;
                }
                else
                    Console.WriteLine("Enter a valid choice");
            }
        }
    }
}
