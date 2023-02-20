using Microsoft.AspNetCore.Mvc;
using Shop.API.Responses;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
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
            List<Employee> employeeList= new List<Employee>();

            var users = this._employeeRepository.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = this._employeeRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost("SaveEmployee")]
        public IActionResult Save([FromBody] Employee emp)
        {
            this._employeeRepository.Save(emp);
            return Ok();
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult Update([FromBody] Employee emp)
        {
            this._employeeRepository.Update(emp);
            return Ok();
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult Delete(Employee emp)
        {
            this._employeeRepository.Remove(emp);
            return Ok();
        }
    }
}
