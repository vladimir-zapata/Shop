using System;

namespace Shop.Web.Models
{
    public class OrdersModel
    {
        public int OrderID { get; set; }
        public int CustID { get; set; }
        public int EmpID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipperID { get; set; }
        public double Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public int ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }
    }

