using day3.Data;
using day3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace day3.Controllers;

public class StudentController : Controller
{
  private readonly ITIDbContext DB = new();

  public IActionResult Index()
  {
    //using select
    //DB.Students.Select(x => new {x.Id, x.Name, x.Department.DeptName}).ToList();
    return View(DB.Students?.Include(a => a.Department).ToList());
  }

  public ActionResult Create()
  {
    ViewBag.depts = new SelectList(DB.Departments.ToList(), "DeptId", "DeptName");
    return View();
  }

  [HttpPost]
  public ActionResult Create(Student std, IFormFile stdimg)
  {
    if (stdimg == null) ModelState.AddModelError("", "image is required");

    if (ModelState.IsValid && stdimg != null)
    {
      DB.Students.Add(std);
      DB.SaveChanges();
      var fileNameWithExt = Student.SaveImageToServer(stdimg, std);
      std.StdImg = fileNameWithExt;
      DB.SaveChanges();
      return RedirectToAction(nameof(Index));
    }

    ViewBag.depts = new SelectList(DB.Departments.ToList(), "DeptId", "DeptName", std.DeptNo);
    return View(std);
  }

  public IActionResult CheckUsername(string UserName)
  {
    var std = DB.Students.FirstOrDefault(s => s.UserName == UserName);
    if (std is null)
      return Json(true);
    return Json(false);
  }

  public IActionResult ChangeNameOrPassword(int? id)
  {
    if (id == null) return NotFound();
    var std = DB.Students.FirstOrDefault(a => a.Id == id);
    if (std == null) return NotFound();
    ViewBag.depts = new SelectList(DB.Departments.ToList(), "DeptId", "DeptName", std.DeptNo);

    return View(std);
  }

  [HttpPost]
  public IActionResult ChangeNameOrPassword(Student Std)
  {
    var std = DB.Students.FirstOrDefault(a => a.Id == Std.Id);
    std.Password = Std.Password;
    std.Email = Std.Email;
    DB.Students.Update(std);
    DB.SaveChanges();

    return RedirectToAction(nameof(Index));
  }

  public IActionResult Delete(int? Id)
  {
    if (Id == null) return NotFound();
    var std = DB.Students.SingleOrDefault(d => d.Id == Id);
    if (std == null) return NotFound();
    DB.Students.Remove(std);
    DB.SaveChanges();
    return RedirectToAction(nameof(Index));
  }

  public IActionResult Edit(int? id)
  {
    if (id == null) return NotFound();
    var std = DB.Students.FirstOrDefault(a => a.Id == id);
    if (std == null) return NotFound();
    return View(std);
  }

  [HttpPost]
  public IActionResult Edit(Student std, IFormFile stdimg)
  {
    string fileNameWithExt = null;
    if (stdimg == null)
      ModelState.AddModelError("", "image is required");
    else
      fileNameWithExt = Student.SaveImageToServer(stdimg, std);

    var studentInfo = DB.Students.FirstOrDefault(a => a.Id == std.Id);
    studentInfo.StdImg = fileNameWithExt;
    studentInfo.Name = std.Name;
    studentInfo.Age = std.Age;

    DB.Students.Update(studentInfo);
    DB.SaveChanges();
    return RedirectToAction(nameof(Index));
  }


  public IActionResult Details(int? id)
  {
    if (id == null) return NotFound();
    var std = DB.Students.Include(a => a.Department).FirstOrDefault(a => a.Id == id);
    if (std is null) return NotFound();
    return View(std);
  }
}