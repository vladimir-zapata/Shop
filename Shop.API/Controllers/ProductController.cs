using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

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
        public IEnumerable<Product> Get()
        {
            return _productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productRepository.GetById(id); ;
        }

        [HttpPost]
        public void Post([FromBody] Product product)
        {
            _productRepository.Save(product);
        }

        [HttpPost("UpdateProduct")]
        public void Put([FromBody] Product product)
        {
            _productRepository.Update(product);
        }

        [HttpPost("DeleteProduct")]
        public void Delete([FromBody] Product product)
        {
            _productRepository.Remove(product);
        }
    }
}
