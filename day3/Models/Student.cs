using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace day3.Models;

//poco class
public class Student
{
  public int Id { get; set; }

  [Required(ErrorMessage = "Name of student is required")]
  [StringLength(10, MinimumLength = 3)]
  public string Name { get; set; }

  [Range(20, 30)] public int Age { get; set; }

  public string StdImg { get; set; }

  [ForeignKey("Department")] public int DeptNo { get; set; }

  [EmailAddress] public string Email { get; set; }
  [Required] public string Password { get; set; }

  [NotMapped][Compare("Password")][DataType(DataType.Password)] public string CPassword { get; set; }

  [Remote("CheckUsername",
    "student",
    ErrorMessage = "Invalid Username Please choose anothor one")]
  public string UserName { get; set; }


  // navigation property
  public virtual Department Department { get; set; }
  public virtual List<StudentCourses> MyCourses { get; set; }

  public static string SaveImageToServer(IFormFile stdimg, Student std)
  {
    var fileNameParts = stdimg.FileName.Split('.');
    var fileExtension = fileNameParts[fileNameParts.Length - 1];
    var fileNameWithExt = $"{std.Id}.{fileExtension}";
    using (var fs = new FileStream($"./wwwroot/images/{fileNameWithExt}"
               , FileMode.Create))
    {
      stdimg.CopyTo(fs);
    }

    return fileNameWithExt;
  }
}