using System;

namespace Shop.API.Request.Users
{
    public class UpdateUserRequest
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int ModifyUser { get; set; }
    }
}
