﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using day3.Data;

#nullable disable

namespace day3.Migrations
{
    [DbContext(typeof(ITIDbContext))]
    partial class ITIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.Property<int>("CourseDepartmentsDeptId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentCoursesCrsId")
                        .HasColumnType("int");

                    b.HasKey("CourseDepartmentsDeptId", "DepartmentCoursesCrsId");

                    b.HasIndex("DepartmentCoursesCrsId");

                    b.ToTable("CourseDepartment");
                });

            modelBuilder.Entity("day3.Models.Course", b =>
                {
                    b.Property<int>("CrsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrsId"), 1L, 1);

                    b.Property<string>("CrsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrsId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("day3.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("DeptName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("day3.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DeptNo")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StdImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeptNo");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("day3.Models.StudentCourses", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CrsId")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CrsId");

                    b.HasIndex("CrsId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.HasOne("day3.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("CourseDepartmentsDeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("day3.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("DepartmentCoursesCrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("day3.Models.Student", b =>
                {
                    b.HasOne("day3.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DeptNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("day3.Models.StudentCourses", b =>
                {
                    b.HasOne("day3.Models.Course", "Course")
                        .WithMany("MyStudents")
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("day3.Models.Student", "Student")
                        .WithMany("MyCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("day3.Models.Course", b =>
                {
                    b.Navigation("MyStudents");
                });

            modelBuilder.Entity("day3.Models.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("day3.Models.Student", b =>
                {
                    b.Navigation("MyCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
