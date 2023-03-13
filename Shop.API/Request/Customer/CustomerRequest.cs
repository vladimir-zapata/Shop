namespace Shop.API.Request.Customer
{
    public class CustomerRequest
    {
        public abstract class ProductRequest : RequestBase
        {

            public string CompanyName { get; set; }
            public string ContactTitle { get; set; }
            public string ContactName { get; set; }
            public int CustomerId { get; set; }

        }
    }
}
