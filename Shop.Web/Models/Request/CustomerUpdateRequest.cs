using System;

namespace Shop.Web.Models.Request
{
    public class CustomerUpdateRequest
    {
        public int customerId { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public DateTime enrollmentDate { get; set; }
        public DateTime modifyDate { get; set; }
        public int modifyUser { get; set; }
    }
}
