﻿// <auto-generated />
using System;
using AttendanceSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AttendanceSystem.Migrations
{
    [DbContext(typeof(AttendanceSystemDbContext))]
    partial class AttendanceSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AttendanceSystem.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Rubaiyad Noor",
                            Password = "asd@123",
                            UserName = "rubaiyad007"
                        });
                });

            modelBuilder.Entity("AttendanceSystem.Models.Attendance", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Present")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("AttendanceSystem.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("ClassStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClassTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Fees")
                        .HasColumnType("float");

                    b.Property<int>("NoOfClasses")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("AttendanceSystem.Models.CourseStudent", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudents", (string)null);
                });

            modelBuilder.Entity("AttendanceSystem.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfClasses")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("AttendanceSystem.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoOfClasses")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Teachers", (string)null);
                });

            modelBuilder.Entity("AttendanceSystem.Models.Attendance", b =>
                {
                    b.HasOne("AttendanceSystem.Models.Course", "Course")
                        .WithMany("Attendances")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AttendanceSystem.Models.Student", "Student")
                        .WithMany("Attendances")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AttendanceSystem.Models.Course", b =>
                {
                    b.HasOne("AttendanceSystem.Models.Admin", "Admin")
                        .WithMany("Courses")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AttendanceSystem.Models.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("AttendanceSystem.Models.CourseStudent", b =>
                {
                    b.HasOne("AttendanceSystem.Models.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AttendanceSystem.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("AttendanceSystem.Models.Student", b =>
                {
                    b.HasOne("AttendanceSystem.Models.Admin", "Admin")
                        .WithMany("Students")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AttendanceSystem.Models.Teacher", "Teacher")
                        .WithMany("Students")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("AttendanceSystem.Models.Teacher", b =>
                {
                    b.HasOne("AttendanceSystem.Models.Admin", "Admin")
                        .WithMany("Teachers")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("AttendanceSystem.Models.Admin", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("AttendanceSystem.Models.Course", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("AttendanceSystem.Models.Student", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("AttendanceSystem.Models.Teacher", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
