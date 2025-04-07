

using ViewModels;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Extentions
{
    public static class EmployeeExtensions
    {
        public static EmpWithDEptListViewModel Expand(this Employee emp, List<Department> departments)
        {
            return new EmpWithDEptListViewModel
            {
                Id = emp.Id,
                Name = emp.Name,
                Salary = emp.Salary,
                JobTitle = emp.JobTitle,
                ImageURL = emp.ImageURL,
                Address = emp.Address,
                DepartmentID = emp.DepartmentID,
                DeptList = departments
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





    }
}
