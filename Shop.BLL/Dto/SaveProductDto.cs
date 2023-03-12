using Shop.BLL.Core;

namespace Shop.BLL.Dto
{
    public class SaveProductDto : DtoBase
    {
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
    }
}
