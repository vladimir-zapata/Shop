using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Contract;
using Shop.BLL.Dtos;



namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeRepository)
        {
            this._employeeService = employeeRepository;
        }

        [HttpGet]

        public IActionResult GetAll() 
        {
            var result = this._employeeService.GetAll();

                return Ok(result);
        }

        [HttpGet("empid")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeService.GetById(id);
            return Ok(employee);
        }

        [HttpPost("CreateEmployee")]
        public IActionResult createEmployee([FromBody] SaveEmployeeDto employee)
        {
            var result = _employeeService.SaveEmployee(employee);
            return Ok(result);
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult ModifiyEmployee([FromBody] UpdateEmployeeDto employee)
        {
            if (employee.EmployeeId == 0) return BadRequest();

            var result = _employeeService.UpdateEmployee(employee);
            return Ok(result);
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult Delete([FromBody] DeleteEmployeeDto employee)
        {
            var result = _employeeService.DeleteEmployee(employee);
            return Ok(result);

        }
    }
}
