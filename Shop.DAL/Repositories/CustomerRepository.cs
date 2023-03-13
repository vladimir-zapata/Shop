﻿using Microsoft.Extensions.Logging;
using Shop.DAL.Context;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return this.context.Customers.Any(st => st.CompanyName == name);
        }

        public List<Customer> GetAll()
        {
            return this.context.Customers
                       .Where(cust => !cust.Deleted)
                       .ToList();
        }

        bool ICustomer.Exists(string companyname)
        {
            return this.context.Customers.Any(st => st.CompanyName == companyname);
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
                Customer customerToRemove = this.GetById(customer.CustId);

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

        public void Save(Customer customer)
        {
            try
            {
                Customer customerToAdd = new Customer()
                {
                    CustId = customer.CustId,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,

                };

                this.context.Customers!.Add(customerToAdd);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error adding customer", ex.ToString());
            }
        }

        public void Update(Customer customer)
        {
            try
            {
                Customer customerToAdd = new Customer()
                {
                    CustId = customer.CustId,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,


                };


                this.context.SaveChanges();

            }
            catch (Exception ex)
            {
                this.ilogger.LogError($"Error updating customer", ex.ToString());
            }
        }

        public IEnumerable<object> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Customer GetEntity(int customerId)
        {
            throw new NotImplementedException();
        }

        public Customer GetEntity(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}