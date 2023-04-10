using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DAL.Core
{
    public abstract class BaseEntity
    {
        [Column("creation_date")]
        public DateTime CreationDate { get; set; }
        [Column("creation_user")]
        public int CreationUser { get; set; }
        [Column("modify_date")]
        public DateTime? ModifyDate { get; set; }
        [Column("modify_user")]
        public int? UserMod { get; set; }
        [Column("delete_user")]
        public int? UserDeleted { get; set; }
        [Column("delete_date")]
        public DateTime? DeletedDate { get; set; }
        [Column("deleted")]
        public bool Deleted { get; set; }
    }
}
