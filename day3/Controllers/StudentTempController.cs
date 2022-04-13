using day3.Data;
using day3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day3.Controllers
{
  public class StudentTempController : Controller
  {
    ITIDbContext db = new ITIDbContext();
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult DoWork1()
    {
      Department dept = db.Departments.SingleOrDefault(dept => dept.DeptId == 200);
      Student student = new Student() { Name = "Ali", Age = 25, DeptNo = 400 };
      db.Students.Add(student);
      db.SaveChanges();
      // using navigation property to add student
      dept.Students.Add(student);

      return Content("Add");
    }

    public IActionResult DoWork2()
    {
      // eager load
      Student std = db.Students.Include(std => std.Department).FirstOrDefault(student => student.Id == 1);
      return Content("eager Load");

    }

    public IActionResult DoWork3()
    {
      //Student std = db.Students.FirstOrDefault(a => a.Id == 1);
      //Course crs = db.Courses.FirstOrDefault(a => a.CrsId == 1);
      try
      {
        db.StudentCourses.Add(new StudentCourses() { StudentId = 1, CrsId = 1, Degree = 90 });
        db.SaveChanges();
        return Content("add");
      }
      catch (Exception)
      {
        return Content("Error occured");
      }


    }
  }
}
