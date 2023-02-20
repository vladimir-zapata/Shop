
namespace Shop.DAL.Core
{
    public  abstract class Customer : AuditEntity
    {
        public int custid { get; set; }
        public string? companyname { get; set; }
        public string? contactname { get; set; }
        public string? contacttitle { get; set; }
    }
}
