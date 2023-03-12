using Microsoft.AspNetCore.Mvc;
using Shop.API.Request.Orders;
using Shop.API.Response.Orders;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System.Collections.Generic;
using Shop.API.Response;
using Shop.BLL.Contract;
using Shop.BLL.Dtos;

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

            var orders = this._ordersService.GetAll();

            return Ok(orders);

        }

        [HttpGet("{id}")]
        public IActionResult GetEntity(int id)
        {
            var result = this._ordersService.GetBbyID(id);

            return Ok(result);
        }


        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder([FromBody] OrdersAddDto ordersAdd)
        {
            var result = this._ordersService.SaveOrder(ordersAdd);

            return Ok(result);
        }


        [HttpPost("UpdateOrder")]
        public IActionResult ModifyOrder([FromBody] OrdersUpdateDto ordersUpdate)
        {
            var result = this._ordersService.UpdateOrder(ordersUpdate);

            return Ok(result);
        }


        [HttpPost("RemoveOrder")]
        public IActionResult Delete([FromBody] OrdersRemoveDto ordersRemove)
        {
            var result = this._ordersService.RemoveOrder(ordersRemove);

            return Ok(result);
        }
    }
}
