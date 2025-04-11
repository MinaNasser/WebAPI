using Microsoft.AspNetCore.Mvc;
using Services;
using WebAPI.Models;
using WebAPIDotNet.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _depServ;

        public DepartmentController(IDepartmentService departmentService)
        {
            _depServ = departmentService;
        }

        [HttpGet("Count")]
        public IActionResult GetDEptDetails()
        {
            List<Department> departments = _depServ.GetAllDepartments();
            List<DeptWithEmpCountDTO> deptWithEmps = new List<DeptWithEmpCountDTO>();
            foreach (Department department in departments)
            {
                {
                    DeptWithEmpCountDTO countDTO = new DeptWithEmpCountDTO();
                    countDTO.Id = department.Id;
                    countDTO.Name = department.Name;
                    countDTO.ManagerName = department.Name;
                    countDTO.EmpCount = department.Employees.Count;
                    deptWithEmps.Add(countDTO);
                }

            }
            return Ok(deptWithEmps);
        }
        // ✅ عرض جميع الأقسام
        [HttpGet]
        public IActionResult DisplayAllDept()
        {
            List<Department> departments = _depServ.GetAllDepartments();
            return Ok(departments);
        }

        // ✅ إضافة قسم جديد مع التحقق من البيانات
        [HttpPost]
        public IActionResult AddDept([FromBody] Department department)
        {
            if (department == null || string.IsNullOrWhiteSpace(department.Name) || string.IsNullOrWhiteSpace(department.ManagerName))
            {
                return BadRequest("Invalid department data. Name and ManagerName are required.");
            }

            _depServ.AddDepartment(department);
            return CreatedAtAction("GetDeptById", new { id = department.Id }, department);
        }

        // ✅ تحديث القسم مع التحقق من البيانات
        [HttpPut("{id:int}")]
        public IActionResult UpdateDept(int id, [FromBody] Department deptFromReq)
        {
            if (deptFromReq == null || string.IsNullOrWhiteSpace(deptFromReq.Name) || string.IsNullOrWhiteSpace(deptFromReq.ManagerName))
            {
                return BadRequest("Invalid department data. Name and ManagerName are required.");
            }

            Department deptFromDB = _depServ.GetDepartmentById(id);
            if (deptFromDB == null)
            {
                return NotFound("Department not found.");
            }

            deptFromDB.Name = deptFromReq.Name;
            deptFromDB.ManagerName = deptFromReq.ManagerName;
            _depServ.UpdateDepartment(deptFromDB);

            return NoContent();
        }

        // ✅ جلب قسم حسب ID
        [HttpGet("{id:int}")]
        public IActionResult GetDeptById(int id)
        {
            Department department = _depServ.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound("Department not found.");
            }
            return Ok(department);
        }

        // ✅ جلب قسم حسب الاسم
        [HttpGet("name/{name:alpha}")]
        public IActionResult GetDeptByName(string name)
        {
            Department department = _depServ.GetDepartmentByName(name);
            if (department == null)
            {
                return NotFound("Department not found.");
            }
            return Ok(department);
        }

        // ✅ حذف القسم حسب ID
        [HttpDelete("{id:int}")]
        public IActionResult DeleteDept(int id)
        {
            Department department = _depServ.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound("Department not found.");
            }

            _depServ.DeleteDepartment(id);
            return NoContent();
        }
    }
}
