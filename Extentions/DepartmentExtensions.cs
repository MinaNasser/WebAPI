using ViewModels;
using WebAPI.Extentions;
using WebAPI.Models;


namespace WebAPI.Extensions
{
    public static class DepartmentExtensions
    {
        public static DepartmentDTO ToDTO(this Department department)
        {
            return new DepartmentDTO
            {
                Id = department.Id,
                Name = department.Name,
                ManagerName = department.ManagerName,
                Employees = department.Employees?.Select(e => e.ToDTO()).ToList()
            };
        }

        public static Department ToModel(this DepartmentDTO dto)
        {
            return new Department
            {
                Id = dto.Id,
                Name = dto.Name,
                ManagerName = dto.ManagerName,
                Employees = dto.Employees?.Select(e => e.ToModel()).ToList()
            };
        }

    }
}
