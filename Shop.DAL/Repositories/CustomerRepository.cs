using System;
using System.Collections.Generic;
using System.Linq;
using Shop.DAL.Context;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using Shop.DAL.Core;
using System.Xml.Linq;

namespace Shop.DAL.Repository

{
    public class CustomerRepository : ICustomer
    {
        private readonly ShopContext context;
        private readonly ILogger<CustomerRepository> ilogger;

        public CustomerRepository(ShopContext context,
                                    ILogger<CustomerRepository> ilogger)
        {
            this.context = context;
            this.ilogger = ilogger;
        }
        public bool Exists(string name)
        {
            return this.context.Customers.Any(st => st.companyname == name);
        }

        public List<Customer> GetAll()
        {
            return this.context.Customers
                       .Where(cust => !cust.Deleted)
                       .ToList();
        }

        bool ICustomer.Exists(string companyname)
        {
            return this.context.Customers.Any(st => st.companyname == companyname);
        }

        public List<Customer> GetAll(string Customer)
        {
        
            return this.context.Customers.Where(x => !x.Deleted).ToList();
        }

         public Customer GetById(int id)
        {
            return context.Customers!.Find(id);
        }

        void ICustomer.Remove(Customer customer)
        {
            try
            {
                Customer customerToRemove = this.GetById(customer.custid);

                customerToRemove.DeleteDate = DateTime.Now;
                customerToRemove.DeleteUser = customer.DeleteUser;
                customerToRemove.Deleted = true;

                this.Update(customerToRemove);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error removing customer", ex.ToString());
            }
        }

        void ICustomer.Save(Customer customer)
        {
            throw new NotImplementedException();
        }

        void ICustomer.Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}