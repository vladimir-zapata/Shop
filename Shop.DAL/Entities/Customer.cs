using Shop.DAL.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DAL.Entities
{
    [Table("Customers", Schema = "Sales")]
    public class Customer : BaseEntity
    {
        [Key]
        [Column("custid")]
        public int custid { get; set; }
        [Column("companyname")]
        public string? CompanyName { get; set; }
        [Column("contactname")]
        public string? contactname { get; set; }
        [Column("contacttitle")]
        public string? contacttitle { get; set; }
        [Column("address")]
        public string? address { get; set; }
        [Column("email")]
        public string? email { get; set; }
        [Column("city")]
        public string? city { get; set; }
        [Column("region")]
        public string? region { get; set; }
        [Column("postalcode")]
        public string? postalcode { get; set; }
        [Column("country")]
        public string? country { get; set; }
        [Column("phone")]
        public string? phone { get; set; }
        [Column("fax")]
        public string? fax { get; set; }

    }
}