using Shop.DAL.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DAL.Entities
{
    [Table("Customers", Schema = "Customer")]
    public class EntityCustomer : Customer
    {
        [Column("custid")]
        public int CustId { get; set; }

        [Column("companyname")]
        public string? Companyname { get; set; }

        [Column("contactname")]
        public string? Contactname { get; set; }

        [Column("contacttitle")]
        public int Contacttitle { get; set; }

    }
}