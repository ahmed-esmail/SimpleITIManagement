using day3.Data;
using day3.Models;
using Microsoft.AspNetCore.Mvc;

namespace day3.Controllers;

public class DepartmentController : Controller
{
  ITIDbContext ITIDb = new ITIDbContext();
  public IActionResult Index()
  {
    List<Department> dept = ITIDb.Departments.ToList();

    return View(dept);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Department dept)
  {
    try
    {
      if (ModelState.IsValid)
      {
        ITIDb.Departments.Add(dept);
        ITIDb.SaveChanges();
        return RedirectToAction("Index");
      }
      else
      {
        return View(dept);
      }

    }
    catch (Exception)
    {
      return Content("ERROR");
    }

  }

  public ActionResult Delete(int? Id)
  {
    if (Id == null)
    {
      return NotFound();
    }
    var dept = ITIDb.Departments.SingleOrDefault(d => d.DeptId == Id);
    if (dept == null)
    {
      return NotFound();
    }
    ITIDb.Departments.Remove(dept);
    ITIDb.SaveChanges();
    return RedirectToAction(nameof(Index));
  }

  public IActionResult Edit(int? id)
  {

    if (id == null)
    {
      return NotFound();
    }
    var dept = ITIDb.Departments.FirstOrDefault(a => a.DeptId == id);
    if (dept == null)
    {
      return NotFound();
    }
    return View(dept);
  }

  [HttpPost]
  public IActionResult Edit(Department dept)
  {
    ITIDb.Departments.Update(dept);
    ITIDb.SaveChanges();
    return RedirectToAction(nameof(Index));
  }
}
