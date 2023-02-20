using Shop.DAL.Entities;
using System.Collections.Generic;

namespace Shop.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        void Save(Employee employee);
        void Update(Employee employee);
        void Remove(Employee employee);
        public Employee GetById(int id);
        List<Employee> GetAll();
        bool Exists(string name);
    }
}
