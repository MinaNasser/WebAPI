using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class EmpAddVM
    {
        
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Salary must be a positive number")]
        //[DataType(DataType.Currency)]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Job Title is required")]
        [StringLength(50, ErrorMessage = "Job Title cannot be longer than 50 characters")]
        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Job Title can only contain letters and spaces")]

        public string JobTitle { get; set; }
        [Required(ErrorMessage = "Image URL is required")]
        //[Url(ErrorMessage = "Invalid URL format")]
        //[StringLength(200, ErrorMessage = "Image URL cannot be longer than 200 characters")]
        //[RegularExpression(@"^(http|https)://.*$", ErrorMessage = "Image URL must start with http:// or https://")]
        [Display(Name ="Image")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters")]
        [RegularExpression(@"^[a-zA-Z0-9\s,.-]+$", ErrorMessage = "Address can only contain letters, numbers, spaces, commas, periods, and hyphens")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Department ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Department ID must be a positive integer")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Department ID must be a positive integer")]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }


    }
}
