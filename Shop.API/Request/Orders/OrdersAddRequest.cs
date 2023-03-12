using System;

namespace Shop.API.Request.Orders
{
    public class OrdersAddRequest : OrderRequest 
    { 
        public DateTime CreateDate { get; set; }
    }
}
