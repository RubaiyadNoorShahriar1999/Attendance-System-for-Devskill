﻿using AttendanceSystem.Models;
using AttendanceSystem.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class AdminPage
    {
        private static readonly AttendanceSystemDbContext db = new AttendanceSystemDbContext();
        public static void AdminOption(Admin admin)
        {

            Console.WriteLine("Task:\n1. Create/Delete a Teacher\n2. Create/Delete a Student\n3. Add/Remove a Course\n4. Assign a course to a student\n5. Set class schedule for a course");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                // take course id and student id from user
                // check if the id exists in the database
                Console.WriteLine("Services:\n1. Add a Teacher 2. Delete a Teacher");
                int addOrDelete= int.Parse(Console.ReadLine());
                if(addOrDelete == 1)
                {
                    Teacher teacher = new Teacher();
                    Console.Write("Enter Teacher name: ");
                    teacher.Name = Console.ReadLine();
                    Console.Write("Enter User name: ");
                    teacher.UserName = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    teacher.Password = Console.ReadLine();
                    teacher.AdminId = admin.Id;
                    Teacher entity = new TeacherServices().Create(teacher);
                    if (entity != null)
                    {
                        Console.Write("Successful, ");
                        Console.WriteLine("Teacher ID: " + entity.Id.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }

                }
                else
                {
                    Console.Write("Enter Teacher ID: ");
                    int tid = int.Parse(Console.ReadLine());

                    if(new TeacherServices().Get(tid) == null)
                    {
                        Console.WriteLine("Teacher doesn't exists");
                        return;
                    }

                    List<Student> students = new StudentServices().GetStudentByTeacherId(tid);

                    foreach(var student in students)
                    {
                        student.TeacherId = null;
                        new StudentServices().Update(student);
                    }

                    var isDeleted = new TeacherServices().Delete(tid);
                    if (isDeleted)
                    {
                        Console.WriteLine("Successful");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }
            }
            else if(choice == 2)
            {
                Console.WriteLine("Services:\n1. Add a Student 2. Delete a Student");
                int addOrDelete = int.Parse(Console.ReadLine());
                if (addOrDelete == 1)
                {
                    Student student = new Student();
                    Console.Write("Enter Student name: ");
                    student.Name = Console.ReadLine();
                    Console.Write("Enter User name: ");
                    student.UserName = Console.ReadLine();
                    Console.Write("Enter password: ");
                    student.Password = Console.ReadLine();
                    student.AdminId = admin.Id;
                    Console.Write("Enter Teacher ID: ");
                    int teacherfk = int.Parse(Console.ReadLine());
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
                        Console.WriteLine("Successful, ");
                        Console.WriteLine("Student ID: " + entity.Id.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }
                else
                {
                    Console.Write("Insert Student ID: ");
                    int ID = int.Parse(Console.ReadLine());
                    Student student = new StudentServices().Get(ID);
                    if(student.TeacherId == null)
                    {
                        Console.Write("Enter a new Teacher ID: ");
                        int tID = int.Parse(Console.ReadLine());
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
                        Console.Write("Successful, ");
                        Console.WriteLine("Student ID: " + ID + " successfully deleted");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Services:\n1. Add a Course 2. Delete a Course");
                int addOrDelete = int.Parse(Console.ReadLine());
                if (addOrDelete == 1)
                {
                    Course course = new Course();
                    Console.Write("Enter Course name: ");
                    course.CourseName = Console.ReadLine();
                    Console.Write("Enter course fees: ");
                    course.Fees = double.Parse(Console.ReadLine());
                    Console.Write("Enter class start date (ex. 2/2/2022): ");
                    course.ClassStartDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter class time (ex. Monday 8PM-11PM,Thursday 8PM-11PM): ");
                    course.ClassTime = Console.ReadLine().Replace(@"\s", "");
                    Console.Write("Enter number of classes: ");
                    course.NoOfClasses = int.Parse(Console.ReadLine());
                    course.AdminId = admin.Id;
                    Console.Write("Enter Teacher ID (You need to assign a teacher to your created course): ");
                    int teacherfk = int.Parse(Console.ReadLine());
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
                        Console.WriteLine("Successful, ");
                        Console.WriteLine("Course ID: " + entity.Id.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }
                else
                {
                    Console.Write("Insert Course ID: ");
                    int ID = int.Parse(Console.ReadLine());
                    Course course = new CourseServices().Get(ID);
                    Console.WriteLine("Enter ID of the Alternative Teacher: ");
                    int backupTeacherID = int.Parse(Console.ReadLine());
                    Teacher isTeacherExist = new TeacherServices().Get(backupTeacherID);
                    if (isTeacherExist == null)
                    {
                        Console.WriteLine("Teacher does not exist");
                        return;
                    }
                    else
                    {
                        course.TeacherId = isTeacherExist.Id;
                    }
                    bool entity = new CourseServices().Delete(ID);
                    if (entity != false)
                    {
                        Console.Write("Successful, ");
                        Console.WriteLine("Course ID: " + ID + " successfully deleted");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }
            }
            else if (choice == 4)
            {
                Course course = new Course();
                Student student = new Student();
                CourseStudent courseStudent = new CourseStudent();
                Console.Write("Enter Course ID: ");
                int courseId = int.Parse(Console.ReadLine());
                Console.Write("Enter Student ID: ");
                int studentId = int.Parse(Console.ReadLine());

                
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

                #region Duplication checking
                /*                CourseStudent cs1 = db.CourseStudents.Where(x => x.CourseId == courseId).FirstOrDefault();
                                CourseStudent cs2 = db.CourseStudents.Where(x => x.CourseId == courseId).FirstOrDefault();*/
                /*                if (cs1 != null && cs2 != null)
                                {
                                }
                                else
                                {
                                    Console.WriteLine("Duplicate ID");
                                }*/
                #endregion 

            }
            else if(choice == 5)
            {
                Schedule schedule = new Schedule();
                Console.Write("Enter Course ID: ");
                schedule.CourseId = int.Parse(Console.ReadLine());
                Console.Write("Enter Teacher ID: ");
                schedule.TeacherId = int.Parse(Console.ReadLine());
                Console.Write("Enter Student ID: ");
                schedule.StudentId = int.Parse(Console.ReadLine());
                Console.Write("Enter number of classes: ");
                schedule.NoOfClasses= int.Parse(Console.ReadLine());
                Console.Write("Enter the class times (ex. Monday 8PM-11PM,Thursday 9PM-11PM): ");
                schedule.ClassTime = Console.ReadLine().Replace(@"\s", ""); 

                Schedule entity = new AdminServices().AssignClassSchedule(schedule);
                if(entity != null)
                {
                    Console.WriteLine("Successfully added a new schedule");
                }
                else
                {
                    Console.WriteLine("Error! Unsuccessful submission");
                }

            }
        }
    }
}
