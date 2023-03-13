using Shop.BLL.Core;
using Shop.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.BLL.Contract
{
    public interface IEmployeeService : IBaseService
    {
        ServiceResult SaveEmployee(SaveEmployeeDto employee);
        ServiceResult UpdateEmployee(UpdateEmployeeDto employee);
        ServiceResult DeleteEmployee(DeleteEmployeeDto employee);

    }

}
