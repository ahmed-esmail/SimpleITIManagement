using System.ComponentModel.DataAnnotations;

namespace day3.Models
{
  public class Course
  {

    public int CrsId { get; set; }
    public string CrsName { get; set; }
    public virtual List<Department> CourseDepartments { get; set; }
    public virtual List<StudentCourses> MyStudents { get; set; }
  }
}
