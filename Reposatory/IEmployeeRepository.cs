﻿using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface IEmployeeRepository
    {
        public void Add(Employee obj);

        public void Update(Employee obj);

        public void Delete(int id);

        public List<Employee> GetAll();
        public Employee GetById(int id);
        public List<Employee> GetByDEptID(int deptId);

        public void Save();
      
    }
}
