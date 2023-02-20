using Shop.DAL.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DAL.Entities
{
    [Table("Users", Schema = "Security")]
    public class User : AuditEntity
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string UserName { get; set; }
    }
}