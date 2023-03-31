using System.Collections.Generic;

namespace Shop.Web.Models.Response.Products
{
    public class ProductListResponse
    {
        public bool Success { get; set; }
        public List<ProductModel> Data { get; set; }
        public string Message { get; set; }
    }
}
