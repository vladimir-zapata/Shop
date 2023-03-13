using System;

namespace Shop.BLL.Dtos
{
    public class CustomerRemoveDto
    {
        public int CustomerId { get; set; }
        public bool Removed { get; set; }
        public DateTime RemoveDate { get; set; }
        public int RemoveUser { get; set; }
    }
}
