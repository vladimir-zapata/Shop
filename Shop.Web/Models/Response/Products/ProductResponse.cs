namespace Shop.Web.Models.Response.Products
{
    public class ProductResponse
    {
        public bool Success { get; set; }
        public ProductModel Data { get; set; }
        public string Message { get; set; }
    }
}
