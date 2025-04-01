using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebAPI.Models;


namespace WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentService DeptServ;
        IEmployeeService EmpService;

        public DepartmentController(IDepartmentService deptRepo, IEmployeeService empRepo)
        {
            DeptServ = deptRepo;
            EmpService = empRepo;
        }

        public IActionResult DeptEmps()
        {
            return View("DeptEmps", DeptServ.GetAllDepartments());//MVC
        }

        public IActionResult GetEmpsByDEptId(int deptId)
        {
            var employees = EmpService.GetEmployeeById(deptId);
                //.Select(e => new
                //{
                //    e.Id,
                //    e.Name,
                //    e.Address,
                //    DepartmentName = e.Department.Name // تجنب تحميل الكائن بالكامل
                //}).ToList();

            return Json(employees);//API
        }


        [Authorize]
        public IActionResult Index()
        {
            List<Department> departmentList = DeptServ.GetAllDepartments();
            return View("Index", departmentList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult SAveAdd(Department newDeptFromRequest)
        {
            if (newDeptFromRequest.Name != null)
            {
                DeptServ.AddDepartment(newDeptFromRequest);
                return RedirectToAction("Index");
            }
            return View("Add", newDeptFromRequest);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var department = DeptServ.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View("Edit", department);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult SaveEdit(Department department)
        {
            if (ModelState.IsValid)
            {
                Department temp = DeptServ.GetDepartmentById(department.Id);
                if (temp != null)
                {
                    temp.Name = department.Name;
                    DeptServ.UpdateDepartment(temp);
                }
                return RedirectToAction("Index");
            }
            return View("Edit", department);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            Department department = DeptServ.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            DeptServ.DeleteDepartment(department.Id);
            return RedirectToAction("Index");
        }
    }
}
