using Shop.DAL.Entities;
using System;

namespace Shop.BLL.Dtos
{
    public class CustomerSaveDto
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }

       
    }
}
