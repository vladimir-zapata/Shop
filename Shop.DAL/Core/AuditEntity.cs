using System;

namespace Shop.DAL.Core
{
    public abstract class AuditEntity
    {
        public AuditEntity()
        {
            CreationDate = DateTime.Now;
            Deleted = false;
        }

        public DateTime? CreationDate { get; set; }
        public int? CreationUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? ModifyUser { get; set; }
        public int? DeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool Deleted { get; set; }
    }
}
