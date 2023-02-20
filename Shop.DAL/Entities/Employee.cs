using Shop.DAL.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.DAL.Entities
{
    [Table("Employees", Schema = "HR")]
    public class Employee : AuditEntity
    {
        [Key]
        [Column("empid")]
        public int Empid { get; set; }

        [Column("firstname")]
        public string? Firstname { get; set; }

        [Column("lastname")]
        public string? Lastname { get; set; }


        [Column("title")]
        public string? Title { get; set; }

        [Column("titleofcourtesy")]
        public string TitleOfCourtesy { get; set; }

        [Column("birthdate")]
        public DateTime? Birthdate { get; set; }

        [Column("hiredate")]
        public DateTime? Hiredate { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("region")]
        public string Region { get; set; }

        [Column("postalcode")]
        public string Postalcode { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("mgrid")]
        public int Mgrid { get; set; }
    }
}

