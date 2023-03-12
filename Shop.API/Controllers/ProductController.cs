using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Contract;
using Shop.BLL.Dto;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) 
        {
            this._productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);

            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody] SaveProductDto product)
        {
            var result = _productService.SaveProduct(product);

            return Ok(result);
        }

        [HttpPost("UpdateProduct")]
        public IActionResult ModifyProduct([FromBody] UpdateProductDto product)
        {
            var result = _productService.UpdateProduct(product);

            return Ok(result);
        }

        [HttpPost("DeleteProduct")]
        public IActionResult Delete([FromBody] DeleteProductDto product)
        {
            var result = _productService.DeleteProduct(product);

            return Ok(result);
        }
    }
}
