using Microsoft.AspNetCore.Mvc;
using Shop.API.Request.Customer;
using Shop.API.Response;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System.Collections.Generic;
using static Shop.API.Request.Customer.AddRequest;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _CustomerRepository;

        public CustomerController(ICustomer customerRepository)
        {
            this._CustomerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<CustomerResponse> customers = new List<CustomerResponse>();

            var customersFromDB = _CustomerRepository.GetAll();

            if (customersFromDB == null) return NotFound("No customer found");

            customersFromDB.ForEach(customer => customers.Add(
                        new CustomerResponse()
                        {
                            CustomerId = customer.CustId,
                            ContactName = customer.ContactName,
                            ContactTitle = customer.ContactTitle,
                            CustomerName = customer.ContactName,

                        }
                  )); ;

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _CustomerRepository.GetById(id);

            if (customer == null) return NotFound("User not found");

            return Ok(new CustomerResponse()
            {
                CustomerId = customer.CustId,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                CustomerName = customer.ContactName,

            });
        }

        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] AddCustomerRequest customer)
        {
            var customerToSave = new Customer()
            {


            };

            _CustomerRepository.Save(customerToSave);

            return Ok();
        }

        [HttpPost("UpdateCustomer")]
        public IActionResult ModifyCustomer([FromBody] ModifyRequest customer)
        {
            var customerToModify = new Customer()
            {
                this._CustomerRepository.Update(customer);
            return Ok();

        

        }

      
        [HttpPost("DeleteCustomer")]
        public IActionResult Delete([FromBody] DeletedRequest customer)
        {
            var customerToRemove = new Customer()
            {
                CustId = customer.CustId,
                DeleteUser = customer.RequestUser
            };

            _CustomerRepository.Remove(customerToRemove);

            return NoContent();
        }
    }
}