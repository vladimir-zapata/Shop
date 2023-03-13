using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.DAL.Context;
using Shop.DAL.Core;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Employee = Shop.DAL.Entities.Employee;

namespace Shop.DAL.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly ShopContext _shopContext;

        public EmployeeRepository(ShopContext shopContext) : base(shopContext)
        {
            this._shopContext = shopContext;
        }

        public override Employee GetEntity(int id)
        {
            return this._shopContext.Employees.FirstOrDefault(Employee=> Employee.empid == id && !Employee.Deleted);
        }

        public override void Update(Employee entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }

    }
}
