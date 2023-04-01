using Shop.BLL.Core;
using Shop.BLL.Dtos;

namespace Shop.BLL.Contract
{
    public interface IEmployeeService
    {
        ServiceResult SaveEmployee(SaveEmployeeDto employee);
        ServiceResult UpdateEmployee(UpdateEmployeeDto employee);
        ServiceResult DeleteEmployee(DeleteEmployeeDto employee);
        ServiceResult GetById(int id);
        ServiceResult GetAll();
    }

}
