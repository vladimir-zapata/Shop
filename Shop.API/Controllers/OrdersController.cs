using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Shop.API.Response.Orders;
using Shop.API.Request.Orders;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            this._ordersRepository = ordersRepository;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            List<OrdersResponse> orders = new List<OrdersResponse>();

            var ordersfromDatabase = _ordersRepository.GetEntities();

            if (ordersfromDatabase == null) return NotFound("No orders found");

            ordersfromDatabase.ForEach(orders => orders.Add(
                        new OrdersResponse()
                        {
                            OrderID = orders.OrderID,
                            OrderDate = orders.OrderDate,
                            ShippedDate = orders.ShippedDate,

                        }
                  ));

            return Ok(orders);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var orders = _ordersRepository.GetEntity(id);

            if (orders == null) return NotFound("User not found");

            return Ok(new OrdersResponse()
            {
                Administrator = orders.Administrator,
                Budget = orders.Budget,
                ShipName = orders.ShipName,
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipRegion = orders.ShipRegion,
                ShipCountry = orders.ShipCountry,
                OrderDate = orders.OrderDate,
            });
        }

        
        [HttpPost("Save")]
        public IActionResult Post([FromBody] OrdersAddRequest orders)
        {
            Orders orderstoAdd = new Orders()
            {
                Administrator = orders.Administrator,
                Budget = orders.Budget,
                CreationDate = orders.CreateDate,
                CreationUser = orders.CreateUser,
                ShipName = orders.ShipName, 
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipRegion = orders.ShipRegion,
                ShipCountry = orders.ShipCountry,
                OrderDate = orders.OrderDate,
            };
            _ordersRepository.Save(orderstoAdd);
            return Ok();
        }

        
        [HttpPut("Update")]
        public IActionResult Put([FromBody] ModifyOrderRequest orders)
        {
            Orders orderstoUpdate = new Orders()
            {
                Administrator = orders.Administrator,
                Budget = orders.Budget,
                CreationDate = orders.CreateDate,
                CreationUser = orders.CreateUser,
                ShipName = orders.ShipName,
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipRegion = orders.ShipRegion,
                ShipCountry = orders.ShipCountry,
                OrderDate = orders.OrderDate,
            };
            _ordersRepository.Update(orderstoUpdate);
            return Ok();
        }

        
        [HttpDelete("Remove")]
        public IActionResult Remove([FromBody] DeleteOrder orders)
        {
            Orders orderstoRemove = new Orders()
            {
                Administrator = orders.Administrator,
                Budget = orders.Budget,
                CreationDate = orders.CreateDate,
                CreationUser = orders.CreateUser,
                ShipName = orders.ShipName,
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipRegion = orders.ShipRegion,
                ShipCountry = orders.ShipCountry,
                OrderDate = orders.OrderDate,
            };
            _ordersRepository.Remove(orderstoRemove);
            return Ok();
        }
    }
}
