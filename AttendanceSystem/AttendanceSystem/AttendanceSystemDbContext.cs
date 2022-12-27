using AttendanceSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class AttendanceSystemDbContext: DbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public AttendanceSystemDbContext()
        {
            _connectionString = @"Server = DESKTOP-1A3PR7B\SQLEXPRESS; Database = AttendanceSystem; Trusted_Connection = True;";
            _migrationAssembly = Assembly.GetExecutingAssembly().GetName().Name;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, (x) => x.MigrationsAssembly(_migrationAssembly));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                        .ToTable("Admins");
            modelBuilder.Entity<Course>()
                        .ToTable("Courses");
            modelBuilder.Entity<Teacher>()
                        .ToTable("Teachers");
            modelBuilder.Entity<Student>()
                        .ToTable("Students");
            modelBuilder.Entity<CourseStudent>()
                        .ToTable("CourseStudents");
            modelBuilder.Entity<Attendance>()
                        .ToTable("Attendances");
            modelBuilder.Entity<Schedule>()
                        .ToTable("Schedules");
                
            #region Admin Relations

            modelBuilder.Entity<Admin>()
                .HasMany(x => x.Courses)
                .WithOne(y => y.Admin)
                .HasForeignKey(z => z.AdminId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Admin>()
                .HasMany(x => x.Teachers)
                .WithOne(y => y.Admin)
                .HasForeignKey(z => z.AdminId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Admin>()
                .HasMany(x => x.Students)
                .WithOne(y => y.Admin)
                .HasForeignKey(z => z.AdminId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Admin>().HasData(new Admin[] {
                new Admin{Id = 1, UserName = "rubaiyad", Name = "Rubaiyad Noor Shahriar", Password = "asd@123"},
            });

            #endregion

            #region Teacher Relation

            modelBuilder.Entity<Teacher>()
                .HasMany(x => x.Students)
                .WithOne(y => y.Teacher)
                .HasForeignKey(z => z.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Teacher>()
                .HasMany(x => x.Courses)
                .WithOne(y => y.Teacher)
                .HasForeignKey(z => z.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);

/*            #region extra portion Course Teacher reverse
            modelBuilder.Entity<Course>()
                .HasOne(x => x.Teacher)
                .WithMany(y => y.Courses)
                .HasForeignKey(z => z.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);
            #endregion*/

            modelBuilder.Entity<Teacher>()
                .HasOne(x => x.Admin)
                .WithMany(y => y.Teachers)
                .HasForeignKey(z => z.AdminId)
                .OnDelete(DeleteBehavior.NoAction);

            /*            modelBuilder.Entity<Teacher>().HasData(new Teacher[] {
                            new Teacher{Id =1,UserName = "jalal007", Name = "jalal", Password = "asd@123", Schedule ="Monday 8PM-11PM,Thursday 8PM-11PM", NoOfClasses = 20,AdminId = 1},
                        });*/

            #endregion

            #region Student Relations
            modelBuilder.Entity<Student>()
                .HasOne(x => x.Admin)
                .WithMany(y => y.Students)
                .HasForeignKey(z => z.AdminId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Student>()
                .HasOne(x => x.Teacher)
                .WithMany(y => y.Students)
                .HasForeignKey(z => z.TeacherId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Student>()
                .HasMany(x => x.Attendances).WithOne(y => y.Student).HasForeignKey(z => z.StudentId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Student>()
                .HasMany(x => x.StudentCourses).WithOne(y => y.Student).HasForeignKey(z => z.StudentId).OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Course and Student Relations

            modelBuilder.Entity<CourseStudent>()
                        .HasKey((x) => new { x.CourseId, x.StudentId });

            modelBuilder.Entity<CourseStudent>()
                        .HasOne(x => x.Course)
                        .WithMany(y => y.CourseStudents)
                        .HasForeignKey(z => z.CourseId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CourseStudent>()
                        .HasOne(x => x.Student)
                        .WithMany(y => y.StudentCourses)
                        .HasForeignKey(z => z.StudentId)
                        .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Course and Student Relations with Attendance

            modelBuilder.Entity<Attendance>()
                        .HasKey((x) => new { x.CourseId, x.StudentId });

            modelBuilder.Entity<Attendance>()
                        .HasOne(x => x.Course)
                        .WithMany(y => y.Attendances)
                        .HasForeignKey(z => z.CourseId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Attendance>()
                        .HasOne(x => x.Student)
                        .WithMany(y => y.Attendances)
                        .HasForeignKey(z => z.StudentId)
                        .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Schedule Relations

            modelBuilder.Entity<Schedule>()
            .HasKey((x) => new { x.CourseId, x.TeacherId,x.StudentId });

            modelBuilder.Entity<Schedule>()
                        .HasOne(x => x.Course)
                        .WithMany(y => y.Schedules)
                        .HasForeignKey(z => z.CourseId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Schedule>()
                        .HasOne(x => x.Teacher)
                        .WithMany(y => y.Schedules)
                        .HasForeignKey(z => z.TeacherId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Schedule>()
                        .HasOne(x => x.Student)
                        .WithMany(y => y.Schedules)
                        .HasForeignKey(z => z.StudentId)
                        .OnDelete(DeleteBehavior.NoAction);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
        #region Tables
        public DbSet<Course> Courses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        #endregion
    }
}
