using System.Collections.Generic;

namespace Shop.Web.Models.Responses
{
    public class CustomerListResponse
    {
        public bool success { get; set; }
        public List<CustomerModel> data { get; set; }
        public string message { get; set; }
    }
}
