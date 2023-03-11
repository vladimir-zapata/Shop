using Shop.DAL.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop.DAL.Entities
{
    [Table("Orders", Schema = "Sales")]
    public class Orders : AuditEntity
    {
        public Orders()
        {
            CreationDate = DateTime.Now;
            Deleted = false;
        }
        [Key]
        [Column("orderid")]
        public int OrderID { get; set; }
        [Column("custid")]
        public int CustomerID { get; set; }
        [Column("empid")]
        public int EmployeeID { get; set; }
        [Column("orderdate")]
        public DateTime? OrderDate { get; set; }
        [Column("requireddate")]
        public DateTime? RequiredDate { get; set; }
        [Column("shippeddate")]
        public DateTime? ShippedDate { get; set; }
        [Column("shipperid")]
        public int ShipperID { get; set; }
        [Column("freight")]
        public decimal Freight { get; set; }
        [Column("shipname")]
        public string ShipName { get; set; }
        [Column("shipaddress")]
        public string ShipAddress { get; set; }
        [Column("shipcity")]
        public string ShipCity { get; set; }
        [Column("shipregion")]
        public string ShipRegion { get; set; }
        [Column("shippostalcode")]
        public string ShipPostalCode { get; set; }
        [Column("shipcountry")]
        public string ShipCountry { get; set; }

    }
}
