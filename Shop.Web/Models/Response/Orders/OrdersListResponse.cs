using System.Collections.Generic;

namespace Shop.Web.Models.Response.Orders

{
    public class OrdersListResponse
    {
        public bool Success { get; set; }
        public List<OrdersModel> Data { get; set; }
        public string Message { get; set; }
    }
}