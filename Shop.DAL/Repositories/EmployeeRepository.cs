using Microsoft.Extensions.Logging;
using Shop.DAL.Context;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ShopContext _employeeContext;
        private readonly ILogger _logger;

        public EmployeeRepository(ShopContext productContext, ILogger<EmployeeRepository> logger)
        {
            this._employeeContext = productContext;
            this._logger = logger;
        }

        

        public void Update(Employee employee)
        {
            try
            {
                Employee employeeToUpdate = this.GetById(employee.Empid);

                employeeToUpdate.Firstname = employee.Firstname;
                employeeToUpdate.Lastname = employee.Lastname;
                employeeToUpdate.Title= employee.Title; 
                employeeToUpdate.TitleOfCourtesy = employee.TitleOfCourtesy;
                employeeToUpdate.Birthdate = employee.Birthdate;
                employeeToUpdate.Hiredate= employee.Hiredate;
                employeeToUpdate.Address= employee.Address;
                employeeToUpdate.City= employee.City;
                employeeToUpdate.Region= employee.Region;
                employeeToUpdate.Postalcode= employee.Postalcode;
                employeeToUpdate.Country= employee.Country;
                employeeToUpdate.Phone= employee.Phone;
                employeeToUpdate.Mgrid= employee.Mgrid;
                employeeToUpdate.ModifyDate= employee.ModifyDate;
                employeeToUpdate.ModifyUser= employee.ModifyUser;

                this._employeeContext.SaveChanges();

            }
            catch (Exception ex)
            {
                this._logger.LogError($"Error updating employee", ex.ToString());
            }
        }

        public void Remove(Employee employee)
        {
            try
            {
                Employee employeeToRemove = this.GetById(employee.Empid);

                employeeToRemove.DeleteDate = DateTime.Now;
                employeeToRemove.DeleteUser = employee.DeleteUser;
                employeeToRemove.Deleted = true;

                this.Update(employeeToRemove);
                this._employeeContext.SaveChanges();

            }
            catch (Exception ex)
            {
                this._logger.LogError($"Error removing employee", ex.ToString());
            }
        }

        

        public void Save(Employee employee)
        {
            try
            {
                Employee employeeToAdd = new Employee()
                {
                    Firstname = employee.Firstname,
                    Lastname = employee.Lastname,
                    Title= employee.Title,
                    TitleOfCourtesy= employee.TitleOfCourtesy,
                    Birthdate= DateTime.Now,
                    Hiredate= DateTime.Now,
                    Address= employee.Address,
                    City= employee.City,
                    Region= employee.Region,
                    Postalcode = employee.Postalcode,
                    Country= employee.Country,
                    Phone= employee.Phone,
                    Mgrid= employee.Mgrid,
                    CreationDate = DateTime.Now,
                    CreationUser = employee.CreationUser
                };

                this._employeeContext.Employees?.Add(employeeToAdd);
                this._employeeContext.SaveChanges();

            }
            catch (Exception ex)
            {
                this._logger.LogError($"Error adding product", ex.ToString());
            }
        }

        public bool Exists(string name)
        {
            return this._employeeContext.Employees.Any(x => x.Firstname == name);
        }

        public Employee GetById(int id)
        {
            return _employeeContext.Employees!.Find(id);
        }

        public List<Employee> GetAll()
        {

            return this._employeeContext.Employees.Where(x => !x.Deleted).ToList();
        }
    }
}