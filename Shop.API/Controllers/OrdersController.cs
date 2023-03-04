using Microsoft.AspNetCore.Mvc;
using Shop.API.Request.Orders;
using Shop.API.Response.Orders;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System.Collections.Generic;
using Shop.API.Response;


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
            List<Orders> employeeList = new List<Orders>();

            var orders = this._ordersRepository.GetEntities();

            return Ok(orders);

        }

        [HttpGet("{id}")]
        public IActionResult GetEntity(int id)
        {
            var orders = _ordersRepository.GetEntity(id);

            if (orders == null) return NotFound("Order not found");

            return Ok(new OrdersResponse()
            {
                OrderID = orders.OrderID,
                ShipName = orders.ShipName,
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipRegion = orders.ShipRegion,
                ShipCountry = orders.ShipCountry,
                OrderDate = orders.OrderDate,
            });
        }


        [HttpPost("Save")]
        public IActionResult CreateOrder([FromBody] OrdersAddRequest orders)
        {
            var orderstoAdd = new Orders()
            {
                OrderID = orders.OrderID,
                ShipName = orders.ShipName,
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipRegion = orders.ShipRegion,
                ShipCountry = orders.ShipCountry,
                OrderDate = orders.OrderDate,
            };

            _ordersRepository.Save(orderstoAdd);
            _ordersRepository.SaveChanges();

            return Ok();
        }


        [HttpPut("Update")]
        public IActionResult ModifyOrder([FromBody] ModifyOrderRequest orders)
        {
            var productToModify = new Orders()
            {
                OrderID = orders.OrderID,
                ShipName = orders.ShipName,
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipRegion = orders.ShipRegion,
                ShipCountry = orders.ShipCountry,
                OrderDate = orders.OrderDate,
            };

            _ordersRepository.Update(productToModify);

            return Ok();
        }


        [HttpDelete("Remove")]
        public IActionResult Delete([FromBody] DeleteOrder orders)
        {
            var productToRemove = new Orders()
            {
                OrderID = orders.OrderID,
                DeleteUser = orders.RequestUser
            };

            _ordersRepository.Remove(productToRemove);

            return NoContent();
        }
    }
}
