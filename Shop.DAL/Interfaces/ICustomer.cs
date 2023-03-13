using Shop.DAL.Entities;
using System.Collections.Generic;

namespace Shop.DAL.Interfaces
{
    public interface ICustomer
    {

        void Save(Customer customer);
        void Update(Customer customer);
        void Remove(Customer customer);
        Customer GetById(int id);
        List<Customer> GetAll();
        bool Exists(string companyname);

    }
}
