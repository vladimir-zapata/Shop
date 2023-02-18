using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Shop.API.Response.Product;
using Shop.API.Request.Product;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) 
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<ProductResponse> products = new List<ProductResponse>();

            var productsFromDB = _productRepository.GetAll();

            if (productsFromDB == null) return NotFound("No products found");

            productsFromDB.ForEach(product => products.Add(
                        new ProductResponse()
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            UnitPrice = product.UnitPrice,
                            CategoryId = product.CategoryId,
                            SupplierId = product.SupplierId,
                            Discontinued = product.Discontinued,
                        }
                  ));

            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productRepository.GetById(id);

            if(product == null) return NotFound("User not found");

            return Ok(new ProductResponse()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                Discontinued = product.Discontinued
            });
        }

        [HttpPost("CreateProduct")]
        public IActionResult CreateProduct([FromBody] AddProductRequest product)
        {
            var productToSave = new Product()
            {
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                CreationUser = product.RequestUser
            };

            _productRepository.Save(productToSave);

            return Ok();
        }

        [HttpPost("UpdateProduct")]
        public IActionResult ModifyProduct([FromBody] ModifyProductRequest product)
        {
            var productToModify = new Product()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                CategoryId = product.CategoryId,
                SupplierId = product.SupplierId,
                Discontinued = product.Discontinued,
                ModifyUser = product.RequestUser 
            };

            _productRepository.Update(productToModify);

            return Ok();
        }

        [HttpPost("DeleteProduct")]
        public IActionResult Delete([FromBody] DeleteProduct product)
        {
            var productToRemove = new Product()
            {
                ProductId = product.ProductId,
                DeleteUser = product.RequestUser
            };

            _productRepository.Remove(productToRemove);

            return NoContent();
        }
    }
}
