using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DAL.Core
{
    public abstract class AuditEntity
    {
        public AuditEntity() 
        {
            CreationDate = DateTime.Now;
            Deleted = false;
        }

        [Column("creation_date")]
        public DateTime? CreationDate { get; set; }

        [Column("creation_user")]
        public int? CreationUser { get; set; }

        [Column("modify_date")]
        public DateTime? ModifyDate { get; set; }

        [Column("modify_user")]
        public int ModifyUser { get; set; }

        [Column("delete_user")]
        public int? DeleteUser { get; set; }

        [Column("delete_date")]
        public DateTime? DeleteDate { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; }
    }
}
