
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models;

namespace WebAPI.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(3000, 10000)]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Enter Job Title Please")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "You Must Upload Image or Re Upload")]
        [RegularExpression(@"\w+\.(jpg|png)", ErrorMessage = "Image Must be .jpg or .png ")]
        public string ImageURL { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]{3,}", ErrorMessage = "Address must be at least 3 letters")]
        public string? Address { get; set; }

        [Display(Name = "Department")]
        [Required]
        public int DepartmentID { get; set; }

    }
}

