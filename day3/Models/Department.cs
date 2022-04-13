using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace day3.Models;

public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int DeptId { get; set; }

    [Required] public string DeptName { get; set; }

    public int Capacity { get; set; }

    // navigation property
    public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

    public virtual List<Course> DepartmentCourses { get; set; }
}