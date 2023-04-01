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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly ILogger _logger;

        public EmployeeService(IEmployeeRepository repository, ILogger<IEmployeeRepository> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                _logger.LogInformation("Consultando Empleados");

                var employees = _repository.GetEntities().ToList();

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
            ServiceResult result = new ServiceResult();

            try
            {
                _logger.LogInformation($"Consultando empleados con id {id}");
                Employee employee = _repository.GetEntity(id);

                if (employee == null || employee.Deleted)
                {
                    result.Success = false;
                    result.Message = $"No se encontró empleado con id {id}";
                }
                else
                {
                    var EmployeeModel = new EmployeeModel()
                    {
                        Empid = employee.Empid,
                        EmployeeName = employee.Firstname,
                        LastName = employee.Lastname
                    };

                    result.Data = EmployeeModel;
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
                 Employee employee = savedEmployee.GetEmployeeFromSaveDto();

                this._repository.Save(employee);
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

        public ServiceResult UpdateEmployee(UpdateEmployeeDto updatedEmployee)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Employee employee = _repository.GetEntity(updatedEmployee.EmployeeId);

                employee.Empid = updatedEmployee.EmployeeId;
                employee.Firstname = updatedEmployee.FirstName;
                employee.Lastname = updatedEmployee.LastName;
                employee.ModifyDate = DateTime.Now;

                this._repository.Update(employee);
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
                Employee employee = _repository.GetEntity(deletedEmployee.EmployeeId);

                employee.DeleteUser = deletedEmployee.EmployeeId;
                employee.DeleteDate = DateTime.Now;
                employee.Deleted = true;

                this._repository.Update(employee);
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

        public ServiceResult GetById(int id, Employee employee1, Employee employee2)
        {
            throw new NotImplementedException();
        }
    }
}
