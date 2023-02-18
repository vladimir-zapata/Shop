namespace Shop.API.Request.Product
{
    public abstract class ProductRequest : RequestBase
    {

        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
