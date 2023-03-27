using Shop.BLL.Dtos;
using Shop.BLL.Contract;
using Microsoft.AspNetCore.Mvc;


namespace itlapr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private  readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var result = this._customerService.GetAll();

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);


        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this._customerService.GetById(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/<StudentController>
        [HttpPost("SaveCustomer")]
        public IActionResult Post([FromBody] CustomerSaveDto customerSaveDto)
        {
            var result = this._customerService.SaveCustomer(customerSaveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        // POST api/<StudentController>
        [HttpPost("UpdateCustomer")]
        public IActionResult Put([FromBody] CustomerUpdateDto customerUpdateDto)
        {
            var result = this._customerService.UpdateCustomer(customerUpdateDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
      
        [HttpPost("RemoveCustomer")]
        public IActionResult Remove([FromBody] CustomerRemoveDto customerRemoveDto)
        {
            var result = this._customerService.RemoveCustomer(customerRemoveDto);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}

