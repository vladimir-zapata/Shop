using Shop.DAL.Core;
using Shop.DAL.Entities;
using System.Collections.Generic;
using Employee = Shop.DAL.Entities.Employee;

namespace Shop.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        object GetEntities();
        Shop.BLL.Dtos.EmployeeDto GetEntity(object empid);
        void update(Shop.BLL.Dtos.EmployeeDto employee);

        public interface IEmployeeRepository : IRepositoryBase<Employee> { }
    }
}
