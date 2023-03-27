

namespace Shop.DAL.Core
{
    public abstract class Customers : BaseEntity
    {
        public string ?CompanyName { get; set; }
        public string ?ContactName { get; set; }

    }
}
