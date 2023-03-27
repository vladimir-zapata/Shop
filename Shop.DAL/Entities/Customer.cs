using Shop.DAL.Core;
using System;


namespace Shop.DAL.Entities
{
    public class Customer : Customers
    {
        public int Id { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}