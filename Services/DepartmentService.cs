using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repository;

namespace Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public List<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public Department GetDepartmentById(int id)
        {
            return _departmentRepository.GetById(id);
        }

        public void AddDepartment(Department department)
        {
            _departmentRepository.Add(department);
            _departmentRepository.Save();
        }

        public void UpdateDepartment(Department department)
        {
            _departmentRepository.Update(department);
            _departmentRepository.Save();
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepository.Delete(id);
            _departmentRepository.Save();
        }
    }

}
