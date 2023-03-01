using Shop.DAL.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shop.DAL.Entities
{
    [Table("Orders", Schema = "Sales")]
    public class Orders : AuditEntity
    {
        public decimal Budget { get; set; }
        public int? Administrator { get; set; }
        public Orders()
        {
            CreationDate = DateTime.Now;
            Deleted = false;
        }
        [Key]
        [Column("orderid")]
        public int OrderID { get; set; }
        [Column("custid")]
        public int CustID { get; set; }
        [Column("empid")]
        public int EmpID { get; set; }
        [Column("orderdate")]
        public DateTime? OrderDate { get; set; }
        [Column("shippeddate")]
        public DateTime? ShippedDate { get; set; }
        [Column("shipperid")]
        public int ShipperID { get; set; }
        [Column("freight")]
        public double Freight { get; set; }
        [Column("shipname")]
        public string ShipName { get; set; }
        [Column("shipaddress")]
        public string ShipAddress { get; set; }
        [Column("shipcity")]
        public string ShipCity { get; set; }
        [Column("shipregion")]
        public string ShipRegion { get; set; }
        [Column("shippostalcode")]
        public int ShipPostalCode { get; set; }
        [Column("shipcountry")]
        public string ShipCountry { get; set; }

    }
}
