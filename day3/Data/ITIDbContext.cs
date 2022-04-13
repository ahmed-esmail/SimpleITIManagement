using day3.Models;
using Microsoft.EntityFrameworkCore;

namespace day3.Data;

public class ITIDbContext : DbContext
{
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<StudentCourses> StudentCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=ITIMVC;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Student>().HasKey(a=> a.Id);
        modelBuilder.Entity<Course>().HasKey(a => a.CrsId);
        modelBuilder.Entity<Course>().Property(a => a.CrsName).IsRequired();
        modelBuilder.Entity<StudentCourses>().HasKey(a => new {a.StudentId, a.CrsId});

        // mapping using Fluent APi 
        //modelBuilder.Entity<Student>()
        //  .HasOne(a => a.Department)
        //  .WithMany(a => a.Students)
        //  .HasForeignKey(a=> a.DeptNo);
    }
}