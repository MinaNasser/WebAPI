using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindingController : ControllerBase
    {
        //api/Binding/12/ahmed
        //api/Binding?age=12&name=ahmed
        [HttpGet("{name:alpha}/{age:int}")]
        public IActionResult testPrimitive(int age, string? name)
        {
            return Ok();
        }

        [HttpPost]//("{name}")]
        public IActionResult TestObj(Department dept, string name)
        {
            return Ok();
        }
        [HttpGet("{Id:int}/{Name:alpha}/{ManagerName:alpha}")]
        //public IActionResult TestCustomBind(int id,string name,string managerNAme)
        public IActionResult TestCustomBind([FromRoute] Department dept)
        {
            return Ok();
        }
    }
}
