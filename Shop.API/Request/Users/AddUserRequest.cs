using System;

namespace Shop.API.Request.Users
{
    public class AddUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int CreationUser { get; set; }

    }
}