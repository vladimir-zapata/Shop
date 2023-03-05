using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Contract;

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

            if(!result.Success) 
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            return Ok(product);
        }

        //[HttpPost("CreateProduct")]
        //public IActionResult CreateProduct([FromBody] AddProductRequest product)
        //{

        //    var productToSave = new Product()
        //    {
        //        ProductName = product.ProductName,
        //        UnitPrice = product.UnitPrice,
        //        CategoryId = product.CategoryId,
        //        SupplierId = product.SupplierId,
        //        CreationUser = product.RequestUser
        //    };

        //    _productRepository.Save(productToSave);

        //    return Ok();
        //}

        //[HttpPost("UpdateProduct")]
        //public IActionResult ModifyProduct([FromBody] ModifyProductRequest product)
        //{
        //    var productToModify = _productRepository.GetEntity(product.ProductId);

        //    if (productToModify == null) return BadRequest();

        //    productToModify.ProductId = product.ProductId;
        //    productToModify.ProductName = product.ProductName;
        //    productToModify.UnitPrice = product.UnitPrice;
        //    productToModify.CategoryId = product.CategoryId;
        //    productToModify.SupplierId = product.SupplierId;
        //    productToModify.Discontinued = product.Discontinued;
        //    productToModify.ModifyUser = product.RequestUser;
        //    productToModify.ModifyDate = DateTime.Now;

        //    _productRepository.Update(productToModify);

        //    return Ok();
        //}

        //[HttpPost("DeleteProduct")]
        //public IActionResult Delete([FromBody] DeleteProduct product)
        //{
        //    var productToDelete = _productRepository.GetEntity(product.ProductId);

        //    if (productToDelete == null) return BadRequest();

        //    productToDelete.DeleteUser = product.RequestUser;
        //    productToDelete.DeleteDate = DateTime.Now;
        //    productToDelete.Deleted = true;

        //    _productRepository.Update(productToDelete);

        //    return NoContent();
        //}
    }
}
