using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using ViewModels;
using WebAPI.Models;
using WebAPI.Extentions;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmpAddVM employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            _employeeService.CreateEmployee(employee.toModel());
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmpAddVM employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            var existingEmployee = _employeeService.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }
            _employeeService.UpdateEmployee(employee.toModel());
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            _employeeService.DeleteEmployee(id);
            return NoContent();
        }
        //[HttpGet("CheckName")]
        //public IActionResult CheckName(string name)
        //{
        //    if (name.Contains("ITI"))
        //    {
        //        return Ok();
        //    }
        //    return BadRequest("Name Must Contain ITI");
        //}

    }
}
