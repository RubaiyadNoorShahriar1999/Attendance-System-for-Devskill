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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Admin> Admins { get; set; }

/*        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }*/

    }
}
