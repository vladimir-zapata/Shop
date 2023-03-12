using Shop.BLL.Core;

namespace Shop.BLL.Dto
{
    public class ProductDto : DtoBase
    {
        public string ProductName { get; set; } = null!;
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
