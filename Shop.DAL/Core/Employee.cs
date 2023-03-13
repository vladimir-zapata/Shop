using System;

namespace Shop.DAL.Core
{
    public abstract class Employee : AuditEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Empid { get; set; }

    }
}
