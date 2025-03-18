using System.ComponentModel.DataAnnotations;

namespace CRUDDemo.Models
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(100, ErrorMessage = "Employee Name can't be longer than 100 characters.")]
        public string? empName { get; set; }

        [Required(ErrorMessage = "Employee Age is required")]
        [Range(18, 100, ErrorMessage = "Employee Age must be between 18 and 100.")]
        public int empAge { get; set; }

        [Required(ErrorMessage = "Employee Number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Employee Number must be a 10-digit number.")]
        public string? empNumber { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string? empDepartment { get; set; }
    }
}
