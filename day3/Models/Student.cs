using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace day3.Models
{
  //poco class
  public class Student
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "Name of student is required"),
      StringLength(10, MinimumLength =3)]
    public string Name { get; set; }
    [Range(20,30)]
    public int Age { get; set; }
    public string StdImg { get; set; }
    [ForeignKey("Department")]
    public int DeptNo { get; set; }
    [RegularExpression(@"[a-zA-z0-9_]+@[A-Za-z0-9]+.[A-Za-z]{2,4}",
      ErrorMessage ="Please provide valid Email")]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [NotMapped]
    [Compare("Password")]
    public string CPassword { get; set; }
    [Remote("CheckUsername", "student")]
    public string UserName { get; set; }


    // navigation property
    public virtual Department Department { get; set; }
    public virtual List<StudentCourses> MyCourses { get; set; }

  }
}
