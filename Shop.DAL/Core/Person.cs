namespace Shop.DAL.Core
{
    public abstract class Person : AuditEntity
    {

        public string? FirsName { get; set; }
        public string? LastName { get; set; }

    }
}