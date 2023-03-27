using System.Collections.Generic;
using Shop.DAL.Entities;
using Shop.DAL.Model;

namespace Shop.DAL.Interfaces
{
    public interface ICustomer
    {
        public interface ICustomerRepository : Core.IRepositoryBase<Customer> 
        {
            
        }
    }
}
