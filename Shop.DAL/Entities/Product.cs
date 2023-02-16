using Shop.DAL.Core;

namespace Shop.DAL.Entities
{
    public class Product : AuditEntity
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public double UnitPrice { get; set; }
        public bool Discontinued { get; set; }
    }
}
