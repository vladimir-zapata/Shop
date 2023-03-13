using Shop.DAL.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DAL.Entities
{
    [Table("Customers", Schema = "Customer")]
    public class Customer : AuditEntity
    {
        public readonly int Id;

        [Column("custid")]
        public int CustId { get; set; }

        [Column("companyname")]
        public string? CompanyName { get; set; }

        [Column("contactname")]
        public string? ContactName { get; set; }

        [Column("contacttitle")]
        public string? ContactTitle { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public int UserDeleted { get; set; }
        public string CustomerName { get; set; }
        public int UserMod { get; set; }
    }
}