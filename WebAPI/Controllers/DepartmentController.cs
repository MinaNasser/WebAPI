using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _depServ;

        public DepartmentController(IDepartmentService departmentService)
        {
            _depServ = departmentService;
        }
        [HttpGet]
        public IActionResult DisplayAllDept()
        {
            List<Department> departments = _depServ.GetAllDepartments();
            return Ok(departments); 
        }
        [HttpPost]
        public IActionResult AddDept(Department department) 
        {
            _depServ.AddDepartment(department);
            //return Created($"http://localhost:29445/api/Department/{department.Id}",department);
            return CreatedAtAction("GetDeptById",new {id=department.Id }, department);
        }
        //public IActionResult UpdateDept(Department department)
        //{

        //}
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetDeptById(int id)
        {
           Department department = _depServ.GetDepartmentById(id);
            return Ok(department);

        }

        [HttpGet("{name:alpha}")]
        public IActionResult GetDeptByName(string name)
        {
            Department department = _depServ.GetDepartmentByName(name);
            return Ok(department);
        }
    }
}
