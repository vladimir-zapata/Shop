using Shop.BLL.Contract;
using Shop.BLL.Core;
using Shop.BLL.Dtos;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.BLL.Exceptions;
using Shop.DAL.Interfaces;
using Shop.BLL.Extentions;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Resources;
using Shop.DAL.Repository;
using System.Runtime.Serialization;

namespace Shop.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository customerRepository;
        private readonly ILogger<CustomerService>? logger;
        


        private object _repository;
        +

        public object CustomerRepository { get; private set; }

        public CustomerService(ICustomer customerRepository,
                              ILogger<CustomerService> logger)
        {
            this.customerRepository = (CustomerRepository?)customerRepository;
            this.logger = logger;
        }

  
        public ServiceResult GetAll()
        {
            
            ServiceResult result = new ServiceResult();

            try
            {
                logger.LogInformation("Consultando clientes");

                var customer = _repository
                                   .GetEntities()
                                   .Select(x => x.GetCustomerModelFromCustomer())
                                   .ToList();

                result.Data = customer;
            }
            catch (CustomerDataException proex)
            {
                result.Success = false;
                result.Message = proex.Message;
                logger.LogError($"{result.Message}", proex.ToString());
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los clientes";
                logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var customer = this.customerRepository.GetEntity(Id);

                CustomerResultModel customerResultModel = new CustomerResultModel()
                {
                    CreationDate = (DateTime)customer.CreationDate,
                    EnrollmentDate = customer.EnrollmentDate.Value,
                    CustomerName = customer.CustomerName,
                    ContactName = customer.ContactName,
                    CustomerId = customer.Id

                };

                result.Data = customerResultModel;
                result.Success = true;
            }
            catch (Exception ex)
            {

                result.Message = "Ocurrió un error obteniendo el cliente";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }

     

        public ServiceResult RemoveCustomer (CustomerRemoveDto removeDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Customer customerToRemove = this.customerRepository.GetEntity(removeDto.CustomerId);

                customerToRemove.Deleted = removeDto.Removed;
                customerToRemove.DeletedDate = removeDto.RemoveDate;
                customerToRemove.UserDeleted = removeDto.RemoveUser;

                this.customerRepository.Update(customerToRemove);

                result.Success = true;
                result.Message = "El cliente ha sido eliminado correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error removiendo el cliente";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }

            return result;
        }

        public ServiceResult SaveCustomer(CustomerSaveDto saveDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult CustomerSave(CustomerSaveDto saveDto)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(saveDto.CompanyName))
            {
                result.Success = false;
                result.Message = "El nombre es requerido";
                return result;
            }

            if (saveDto.ContactName.Length > 50)
            {
                result.Success = false;
                result.Message = "La logitud del nombre es inválida";
                return result;
            }

            if (string.IsNullOrEmpty(saveDto.ContactName))
            {
                result.Success = false;
                result.Message = "El nombre del contato es requerido";
                return result;
            }
            if (saveDto.CompanyName.Length > 50)
            {
                result.Success = false;
                result.Message = "La logintud del nombre del contato es inválida";
                return result;
            }

            if (!saveDto.EnrollmentDate.HasValue)
            {
                result.Success = false;
                result.Message = "La fecha de inscripción es requerida.";
                return result;

            }

            try
            {
                Customer customer = saveDto.GetCustomerEntityFromDtoSave();
                this.customerRepository.Save(customer);
                result.Success = true;
                result.Message = "El cliente ha sido agregado correctamente.";

            }
            catch (CustomerDataException sdex)
            {
                result.Message = sdex.Message;
                result.Success = false;
                this.logger.LogError(result.Message, sdex.ToString());
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error agregando el cliente";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }

            return result;
        }

        ServiceResult ICustomerService.UpdateCustomer(CustomerUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}

namespace Shop.BLL
{
    [Serializable]
    class CustomerDataException : Exception
    {
     

        public CustomerDataException(string message) : base(message)
        {
        }

        public CustomerDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}