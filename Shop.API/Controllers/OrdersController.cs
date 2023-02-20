using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Shop.DAL.Interfaces;
using Shop.DAL.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {   
            this.ordersRepository = ordersRepository;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            return this.ordersRepository.GetAll();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public Orders Get(int id)
        {
            return this.ordersRepository.GetbyId(id);
        }

        [HttpPost]
        public void Post([FromBody] Orders orders)
        {
            this.ordersRepository.Save(orders);
        }

        [HttpPost]
        public void Put(Orders order)
        {
            this.ordersRepository.Update(order);
        }

        [HttpPost]
        public void Delete(Orders order)
        {
            this.ordersRepository.Remove(order);
        }
    }
}
