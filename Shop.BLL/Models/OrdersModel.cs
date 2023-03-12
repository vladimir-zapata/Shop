using System;

namespace Shop.BLL.Models
{
    public class OrdersModel
    {
        public int OrderID { get; set; }
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
        public string OrderDateDisplay
        {
            get { return this.OrderDate.ToString("dd/MM/yyyy"); }
        }
            public string ShippedDateDisplay
        {
            get { return this.ShippedDate.ToString("dd/MM/yyyy"); }
        }
        public string RequiredDateDisplay
        {
            get { return this.ShippedDate.ToString("dd/MM/yyyy"); }
        }
    }
}
