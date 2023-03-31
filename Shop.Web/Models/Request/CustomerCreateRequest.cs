using System;

namespace Shop.Web.Models.Request
{
    public class CustomerCreateRequest
    {
        public string companyName { get; set; }
        public string contactName { get; set; }
        public DateTime enrollmentDate { get; set; }
        public DateTime creationDate { get; set; }
        public int creationUser { get; set; }
    }
}
