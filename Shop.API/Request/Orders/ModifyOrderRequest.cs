using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.API.Request.Orders
{
    public class ModifyOrderRequest : OrderRequest
    {
        public int OrderId { get; set; }
        public string ShipAdress { get; set; }
    }
}
