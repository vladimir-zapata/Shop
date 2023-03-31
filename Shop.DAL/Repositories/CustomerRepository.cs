using Microsoft.Extensions.Logging;
using Shop.DAL.Context;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static Shop.DAL.Interfaces.ICustomer;

namespace Shop.DAL.Repository

{
    public class CustomerRepository : Core.RepositoryBase<Customer>, ICustomerRepository
    {

        private readonly ShopContext _shopContext;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(ShopContext shopContext, ILogger<CustomerRepository> logger) : base(shopContext)
        {
            _shopContext = shopContext;
            _logger = logger; 
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
