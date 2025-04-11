

using ViewModels;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Extentions
{
    public static class EmployeeExtensions
    {
        public static EmpWithDeptListViewModel Expand(this Employee emp)
        {
            return new EmpWithDeptListViewModel
            {
                Id = emp.Id,
                Name = emp.Name,
                Salary = emp.Salary,
                JobTitle = emp.JobTitle,
                ImageURL = emp.ImageURL,
                Address = emp.Address,
                DepartmentID = emp.DepartmentID,

            };
        }
        public static EmpAddVM toVMModel(this Employee emp)
        {
            return new EmpAddVM
            {
                //Id = id,
                Name = emp.Name,
                Salary = emp.Salary,
                JobTitle = emp.JobTitle,
                ImageURL = emp.ImageURL,
                Address = emp.Address,
                DepartmentID = emp.DepartmentID
            };

        }
        public static Employee toModel(this EmpAddVM emp)
        {
            return new Employee
            {
                Id = emp.Id,
                Name = emp.Name,
                Salary = emp.Salary,
                JobTitle = emp.JobTitle,
                ImageURL = emp.ImageURL,
                Address = emp.Address,
                DepartmentID = emp.DepartmentID
            };
        }
        public static EmpWithDeptListViewModel ToDTO(this Employee employee)
        {
            return new EmpWithDeptListViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Salary = employee.Salary,
                JobTitle = employee.JobTitle,
                ImageURL = employee.ImageURL,
                Address = employee.Address,
                DepartmentID = employee.DepartmentID
            };
        }

        public static Employee ToModel(this EmpWithDeptListViewModel dto)
        {
            return new Employee
            {
                Id = dto.Id,
                Name = dto.Name,
                Salary = dto.Salary,
                JobTitle = dto.JobTitle,
                ImageURL = dto.ImageURL,
                Address = dto.Address,
                DepartmentID = dto.DepartmentID
            };
        }




    }
}
