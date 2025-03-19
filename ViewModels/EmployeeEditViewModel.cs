using System.ComponentModel.DataAnnotations;

namespace CRUDDemo.ViewModels
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        [Required(ErrorMessage ="Id is required")]
        public int Id { get; set; }

    }
}
