using Microsoft.Extensions.Logging;
using Shop.DAL.Context;
using Shop.DAL.Core;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL.Repository

{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {

        private readonly ShopContext _shopContext;

        public CustomerRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }
        public override List<Customer> GetEntities()
        {
            var customers = this._shopContext.Customers.Where(dep => !dep.Deleted).ToList();
            
            
            return customers;

        }
        public bool Exists(string name)
        {
            return this._shopContext.Customers.Count(cd => cd.CompanyName == name) > 1;
            
        }

        public Customer GetEntity(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
