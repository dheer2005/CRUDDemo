using System.ComponentModel.DataAnnotations;

namespace CRUDDemo.ViewModels
{
    public class EmployeeViewModel : EmployeeCreateViewModel
    {
        [Required(ErrorMessage ="Id is required")]
        public int Id { get; set; } 
    }
}
