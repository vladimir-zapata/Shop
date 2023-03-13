using System;
using System.Linq;
using System.Net;
using Microsoft.Extensions.Logging;
using Shop.BLL.Contract;
using Shop.BLL.Core;
using Shop.BLL.Dtos;
using Shop.BLL.Extentions;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Exceptions;
using Shop.DAL.Interfaces;

namespace Shop.BLL.Services
{
    public class EmployeeService : EmployeeServiceBase, IEmployeeService
    {
        private readonly IEmployeeRepository _employee;
        private readonly object repository;
        private readonly ILogger _logger;

        public EmployeeService(IEmployeeRepository repositoy, ILogger<IEmployeeRepository> logger)
        {
            repository = repository;
            this._logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                _logger.LogInformation("Consultando Empleados");

                var employees = _employee
                    .GetEntities()
                    .select(x => x.GetEmployeeModelFromEmployee())
                    .ToList();

                result.Data = employees;
            }

            catch (EmployeeDataException proex)
            {
                result.Success = false;
                result.Message = proex.Message;
                _logger.LogError($"{result.Message}", proex.ToString());
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los empleados";
                _logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;

        }

        public ServiceResult GetById(int id)
        {
            return GetById(id, employee);
        }

        public ServiceResult GetById(int id, Employee employee)
        {
            return GetById(id, employee, employee);
        }

        public ServiceResult GetById(int id, Employee employee, Employee employee)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                _logger.LogInformation($"Consultando empleados con id {id}");
                Employee Employee = repository.GetEntity(id);

                if (Employee == null || Employee.Deleted)
                {
                    result.Success = false;
                    result.Message = $"No se encontró empleado con id {id}";
                }
                else
                {
                    var EmployeeModel1 = employee.GetEmployeeModel1FromEmployee();

                    result.Data = EmployeeModel1;
                }
            }

            catch (EmployeeDataException proex)
            {
                result.Success = false;
                result.Message = proex.Message;
                _logger.LogError($"{result.Message}", proex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error obteniendo empleado: {id}";
                _logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult SaveEmployee(SaveEmployeeDto savedEmployee)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                EmployeeDto employee = savedEmployee.GetEmployeeFromSaveDto();

                this._employee.Save(employee);
                result.Success = true;
                result.Message = "El empleado ha sido añadido correctamente";
            }

            catch (EmployeeDataException proex)
            {
                result.Success = false;
                result.Message = proex.Message;
                _logger.LogError($"{result.Message}", proex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error guardando el empleado";
                _logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult UpdateEmployee(UpdateEmployeeDto updatedEmployee, IEmployeeRepository _employee)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                EmployeeDto employee = _employee.GetEntity(UpdateEmployee.Empid);

                employee.EmployeeId = updatedEmployee.EmployeeId;
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.ModifyDate = DateTime.Now;

                this._employee.update(employee);
                result.Success = true;
                result.Message = "El empleado ha sido modificado con éxito";
            }

            catch (EmployeeDataException proex)
            {
                result.Success = false;
                result.Message = proex.Message;
                _logger.LogError($"{result.Message}", proex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error modificando el empleado";
                _logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult DeleteEmployee(DeleteEmployeeDto deletedEmployee)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                EmployeeDto employee = _employee.GetEntity(DeleteEmployee.Employeeid);

                employee.DeleteUser = deleteEmployee.RequestUser;
                employee.DeleteDate = DateTime.Now;
                employee.Deleted = true;

                this._employee.update(employee);
                result.Success = true;
                result.Message = "El empleado ha sido eliminado correctamente";
            }

            catch (EmployeeDataException proex)
            {
                result.Success = false;
                result.Message = proex.Message;
                _logger.LogError($"{result.Message}", proex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error eliminando el empleado";
                _logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
