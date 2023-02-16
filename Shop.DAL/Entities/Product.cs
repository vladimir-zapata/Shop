using Shop.DAL.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DAL.Entities
{
    [Table("Products", Schema = "Production")]
    public class Product : AuditEntity
    {
        [Column("productid")]
        public int ProductId { get; set; }

        [Column("productname")]
        public string? ProductName { get; set; }

        [Column("supplierid")]
        public int SupplierId { get; set; }

        [Column("categoryid")]
        public int CategoryId { get; set; }

        [Column("unitprice")]
        public decimal UnitPrice { get; set; }

        [Column("discontinued")]
        public bool Discontinued { get; set; }
    }
}
