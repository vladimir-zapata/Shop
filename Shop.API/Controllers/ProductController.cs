using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Shop.API.Response.Product;
using Shop.API.Request.Product;
using System;

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

            var productsFromDB = _productRepository.GetEntities();

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
            var product = _productRepository.GetEntity(id);

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
            var productToModify = _productRepository.GetEntity(product.ProductId);

            if (productToModify == null) return BadRequest();

            productToModify.ProductId = product.ProductId;
            productToModify.ProductName = product.ProductName;
            productToModify.UnitPrice = product.UnitPrice;
            productToModify.CategoryId = product.CategoryId;
            productToModify.SupplierId = product.SupplierId;
            productToModify.Discontinued = product.Discontinued;
            productToModify.ModifyUser = product.RequestUser;
            productToModify.ModifyDate = DateTime.Now;

            _productRepository.Update(productToModify);

            return Ok();
        }

        [HttpPost("DeleteProduct")]
        public IActionResult Delete([FromBody] DeleteProduct product)
        {
            var productToDelete = _productRepository.GetEntity(product.ProductId);

            if (productToDelete == null) return BadRequest();

            productToDelete.DeleteUser = product.RequestUser;
            productToDelete.DeleteDate = DateTime.Now;
            productToDelete.Deleted = true;

            _productRepository.Update(productToDelete);

            return NoContent();
        }
    }
}
