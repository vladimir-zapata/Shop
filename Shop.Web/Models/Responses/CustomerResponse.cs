namespace Shop.Web.Models.Responses
{
    public class CustomerResponse
    {
        public bool success { get; set; }
        public CustomerModel data { get; set; }

        public string message { get; set; }
    }
}
