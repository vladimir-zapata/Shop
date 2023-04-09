namespace Shop.Web.Models.Response.Orders
{
    public class OrdersResponse
    {
        public bool Success { get; set; }
        public OrdersModel Data { get; set; }
        public string Message { get; set; }
    }
}