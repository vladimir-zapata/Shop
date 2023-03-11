using Microsoft.AspNetCore.Mvc;
using Shop.API.Request.Orders;
using Shop.API.Response.Orders;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System.Collections.Generic;
using Shop.API.Response;
using Shop.BLL.Contract;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this._ordersService = ordersService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Orders> employeeList = new List<Orders>();

            var orders = this._ordersService.GetAll();

            return Ok(orders);

        }

        [HttpGet("{id}")]
        public IActionResult GetEntity(int id)
        {
            var result = this._ordersService.GetBbyID(id);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpPost("Save")]
        public IActionResult CreateOrder([FromBody] OrdersAddRequest orders)
        {
            var orderstoAdd = new Orders()
            {
                OrderID = orders.OrderID,
                CustomerID = orders.CustomerID,
                EmployeeID = orders.EmployeeID,
                OrderDate = orders.OrderDate,
                RequiredDate = orders.RequiredDate,
                ShippedDate = orders.ShippedDate,
                ShipperID = orders.ShipperID,
                Freight = (decimal)orders.Freight,
                ShipName = orders.ShipName,
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipRegion = orders.ShipRegion,
                ShipPostalCode = orders.ShipPostalCode,
                ShipCountry = orders.ShipCountry,
                CreationUser = orders.RequestUser
            };

           // _ordersRepository.Save(orderstoAdd);
           // _ordersRepository.SaveChanges();

            return Ok();
        }


        [HttpPut("Update")]
        public IActionResult ModifyOrder([FromBody] ModifyOrderRequest orders)
        {
            var productToModify = new Orders()
            {
                OrderID = orders.OrderID,
                CustomerID = orders.CustomerID,
                EmployeeID = orders.EmployeeID,
                OrderDate = orders.OrderDate,
                RequiredDate = orders.RequiredDate,
                ShippedDate = orders.ShippedDate,
                ShipperID = orders.ShipperID,
                Freight = (decimal)orders.Freight,
                ShipName = orders.ShipName,
                ShipAddress = orders.ShipAddress,
                ShipCity = orders.ShipCity,
                ShipRegion = orders.ShipRegion,
                ShipPostalCode = orders.ShipPostalCode,
                ShipCountry = orders.ShipCountry,
            };

            //_ordersRepository.Update(productToModify);

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

            //_ordersRepository.Remove(productToRemove);

            return NoContent();
        }
    }
}
