using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.BLL.Extentions
{
    public static class EmployeeExtention
    {
        public static employee GetEmployeeFromSaveDto(this Dtos.SaveEmployeeDto saveEmployee)
        {
            Employee employee = new employee()
            {
                EmployeeName = saveEmployee.EmployeeName,
                EmployeeId = saveEmployee.EmployeeId,
                EmployeeLastName = saveEmployee.EmployeeLastName,
                CreationUser = saveEmployee.RequestUser,
                creationDate = DateTime.Now,
            };

            return employee;
        }

        public static EmployeeModel1 GetEmployeeModel1FromEmployee(this Employee employee)
        {
            EmployeeModel pm = new EmployeeModel1()
            {
                EmployeeName = employee.EmployeeName,
                EmployeeId = employee.EmployeeId,
                EmployeeLastName = employee.EmployeeLastName,
                CreationDate = DateTime.Now,
            };
            return pm;
        }
    }
}
