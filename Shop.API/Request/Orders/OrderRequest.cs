namespace Shop.API.Request.Orders
{
    public class OrderRequest : RequestBase
    {
        
        public int shipperID { get; set; }
        public int orderID { get; set; }
        public string shipAddress { get; set; }
        public string shipName { get; set; }
    }
}
