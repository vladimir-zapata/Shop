using Microsoft.AspNetCore.Mvc;
using Shop.API.Request.Users;
using Shop.API.Response.User;
using Shop.BLL.Contract;
using Shop.BLL.Dtos;
using Shop.DAL.Entities;
using System.Collections.Generic;
using TechTalk.SpecFlow.CommonModels;


namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
       

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<UserResponse> userList = new List<UserResponse>();

            var users = _userService.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost("SaveUser")]
        public IActionResult Save([FromBody] UserAddDtos userRequest)
        {
            var result = this._userService.SaveUser(userRequest);

            return Ok(result);
        }

        [HttpPost("UpdateUser")]
        public IActionResult Update([FromBody] UserUpdateDtos userUpdate)
        {
            var result = this._userService.UpdateUser(userUpdate);

            return Ok(result);
        }

        [HttpPost("DeleteUser")]
        public IActionResult Delete([FromBody] UserRemoveDtos userDelete)
        {
            var result = this._userService.RemoveUser(userDelete);

            return Ok(result);
        }
    }
}
