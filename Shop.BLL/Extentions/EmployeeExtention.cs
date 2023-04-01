using Shop.BLL.Dtos;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.BLL.Extentions
{
    public static class EmployeeExtention
    {
        public static Employee GetEmployeeFromSaveDto(this SaveEmployeeDto saveEmployee)
        {
            Employee employee = new Employee()
            {
                Firstname = saveEmployee.Firstname,
                Lastname = saveEmployee.Lastname,
                Address = "Una direccion",
                City =  "Ciudad",
                Birthdate= DateTime.Now,
                Country = "Una pais",
                Title = "Titulo",
                Mgrid = 0,
                TitleOfCourtesy = "Sr.",
                Hiredate= DateTime.Now, 
                Phone = "8098889090",
                CreationUser = 5,
                CreationDate = DateTime.Now,
            };

            return employee;
        }

        public static EmployeeModel GetEmployeeModel1FromEmployee(this Employee employee)
        {
            EmployeeModel pm = new EmployeeModel()
            {
                EmployeeName = employee.Firstname,
                Empid = employee.Empid,
                LastName = employee.Lastname,
            };
            return pm;
        }
    }
}
