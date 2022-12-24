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

            #region Admin Relation
            modelBuilder.Entity<Admin>()
                .HasMany(x => x.Courses)
                .WithOne(y => y.Admin)
                .HasForeignKey(z => z.AdminId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Admin>()
                .HasMany(x => x.Teachers)
                .WithOne(y => y.Admin)
                .HasForeignKey(z => z.AdminId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Admin>()
                .HasMany(x => x.Students)
                .WithOne(y => y.Admin)
                .HasForeignKey(z => z.AdminId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Teacher Relation

            modelBuilder.Entity<Teacher>()
                .HasMany(x => x.Students)
                .WithOne(y => y.Teacher)
                .HasForeignKey(z => z.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Teacher>()
                .HasMany(x => x.Courses)
                .WithOne(y => y.Teacher)
                .HasForeignKey(z => z.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Course and Student Relation

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

            #region Course and Student Relation Attendance

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

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
