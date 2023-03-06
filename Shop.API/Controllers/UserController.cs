using Microsoft.AspNetCore.Mvc;
using Shop.API.Request.Users;
using Shop.API.Response.User;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System.Collections.Generic;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<UserResponse> userList = new List<UserResponse>();

            var users = _userRepository.GetEntities();

            users.ForEach(user => userList.Add(new UserResponse()
            {
                Name = user.Name,
                Email = user.Email,
            }));

            return Ok(userList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userRepository.GetEntity(id);

            if (user == null) return NotFound();

            return Ok(new UserResponse() { Name = user.Name, Email = user.Email });
        }

        [HttpPost("SaveUser")]
        public IActionResult Save([FromBody] AddUserRequest userRequest)
        {
            var user = new User()
            {
                Email = userRequest.Email,
                Password = userRequest.Password,
                Name = userRequest.Name,
                CreationUser = userRequest.CreationUser
            };

            this._userRepository.Save(user);
            return Ok();
        }

        [HttpPut("UpdateUser")]
        public IActionResult Update([FromBody] UpdateUserRequest userUpdate)
        {
            var user = new User()
            {
                UserId = userUpdate.UserId,
                Email = userUpdate.Email,
                Password = userUpdate.Password,
                Name = userUpdate.Name,
                ModifyUser = userUpdate.ModifyUser
            };

            this._userRepository.Update(user);
            return Ok();
        }

        [HttpDelete("DeleteUser")]
        public IActionResult Delete([FromBody] DeleteUserRequest userDelete)
        {
            var user = new User()
            {
                UserId = userDelete.UserId,
                DeleteUser = userDelete.DeleteUser
            };

            this._userRepository.Remove(user);

            return Ok();
        }
    }
}
