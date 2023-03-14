using Shop.BLL.Core;
using System;

namespace Shop.BLL.Dtos
{
     public class UserUpdateDtos : UserBaseDatos
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
    }
}
