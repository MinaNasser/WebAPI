
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebAPI.Data;
using WebAPI.Models;


namespace WebAPI.Domain

{
    public class UniqNameAttribute: ValidationAttribute
    {
        public string msg { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            string newName = value.ToString();
            ITIContext context = new ITIContext();
            Employee employeeDB= context.Employee.FirstOrDefault(e => e.Name == newName);
            Employee employeeForm =(Employee) validationContext.ObjectInstance;

            if (employeeDB != null)
            {
                return new ValidationResult("Name Must be Uniq");
            }
            return ValidationResult.Success;
        }
    }
}


 