using Microsoft.AspNetCore.Mvc;
using Shop.API.Request.Employee;
using Shop.API.Responses;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Shop.DAL.Repositories;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet]

        public IActionResult GetAll() 
        {
            var result = this._employeeRepository.GetAll();

            if (!result.success)
                return BadRequest(result);
                return Ok(result);
        }

        [HttpGet("empid")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return Ok(employee);
        }

        [HttpPost("CreateEmployee")]
        public IActionResult createEmployee([FromBody] SaveEmployeeDto employee)
        {
            var result = _employeeRepository.SaveEmployee(employee);
            return Ok(result);
        }

        [HttpPost("UpdateEmployee")]
        public IActionResult ModifiyEmployee([FromBody] UpdateEmployeeDto employee)
        {
            if (employee.Employeeid == 0) return BadRequest();
            if (employee.Employeeid == 0) return BadRequest();

            var result = _employeeRepository.UpdateEmployee(employee);
            return Ok(result);
        }

        [HttpPost("DeleteProdcut")]
        public IActionResult Delete([FromBody] DeleteEmployeeDto employee)
        {
            var result = _employeeRepository.DeleteEmployee(employee);
            return Ok(result);

        }
    }
}
