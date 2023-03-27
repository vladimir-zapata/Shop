using System;


namespace Shop.DAL.Model
{
    internal class CustomerModel
    {
        public int Id { get; set; }

        public string ?CompanyName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
