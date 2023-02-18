using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.API.Request.Product
{
    public class ModifyProductRequest : ProductRequest
    {
        public int ProductId { get; set; }
        public bool Discontinued { get; set; }
    }
}
