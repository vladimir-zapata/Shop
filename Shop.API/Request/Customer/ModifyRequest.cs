namespace Shop.API.Request.Customer
{
    public class ModifyRequest
    {
        public class ModifyCustomerRequest : CustomerRequest
        {
            public int CustId { get; set; }
        
        }
    }
}
