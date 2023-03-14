using Shop.BLL.Core;
using System;

namespace Shop.BLL.Dtos
{
    public class UserAddDtos : UserBaseDatos
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
    }
}
