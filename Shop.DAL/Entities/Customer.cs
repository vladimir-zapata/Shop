using Shop.DAL.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DAL.Entities
{
    [Table("Customers", Schema = "Customer")]
    public class Customer : AuditEntity
    {
        [Column("custid")]
        public int CustId { get; set; }

        [Column("companyname")]
        public string? CompanyName { get; set; }

        [Column("contactname")]
        public string? ContactName { get; set; }

        [Column("contacttitle")]
        public int ContactTitle { get; set; }

    }
}