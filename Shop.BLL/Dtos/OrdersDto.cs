using Shop.BLL.Core;
using System;

namespace Shop.BLL.Dto
{
    public class OrdersDto : BaseDtos
    {
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int ShipperID { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime RequiredDate { get; set; }
    }
}