namespace Shop.Web.ViewModels.Products
{
    public abstract class BaseRequest
    {
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public double UnitPrice { get; set; }
        public int RequestUser { get; set; }
    }
}