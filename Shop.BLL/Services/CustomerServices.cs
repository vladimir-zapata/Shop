using Shop.BLL.Logger;
using Shop.BLL.Core;
using Shop.BLL.Contract;
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


namespace shop.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository customerRepository;
        private readonly ILogger<CustomerService> logger;

        public CustomerService(CustomerRepository customerRepository,
                              ILogger<CustomerService> logger)
        {
            this.customerRepository = customerRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var customers = this.customerRepository.GetEntities().Select(cd => new CustomerResultModel()
                {
                    CreationDate = cd.CreationDate,
                    EnrollmentDate = cd.EnrollmentDate.Value,
                    CompanyName = cd.CompanyName,
                    ContactName = cd.ContactName,
                    CustomerId = cd.Id
                }).ToList();

                result.Data = customers;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo los clientes";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
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
                    CreationDate = customer.CreationDate,
                    EnrollmentDate = customer.EnrollmentDate.Value,
                    CompanyName = customer.CompanyName,
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

        public ServiceResult RemoveCustomer(CustomerRemoveDto removeDto)
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

            this.logger.LogInformation("Paso por aqui", saveDto.CompanyName);
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(saveDto.CompanyName))
            {
                result.Success = false;
                result.Message = "El nombre es requerido";
                return result;
            }

            if (saveDto.CompanyName.Length > 50)
            {
                result.Success = false;
                result.Message = "La logitud del nombre es inválida";
                return result;
            }

            if (string.IsNullOrEmpty(saveDto.ContactName))
            {
                result.Success = false;
                result.Message = "El contacto es requerido";
                return result;
            }
            if (saveDto.CompanyName.Length > 50)
            {
                result.Success = false;
                result.Message = "La logintud del contacto es inválida";
                return result;
            }

            if (!saveDto.EnrollmentDate.HasValue)
            {
                result.Success = false;
                result.Message = "La fecha de inicio es requerida.";
                return result;

            }

            try
            {
                Customer customer = saveDto.GetCustomerEntityFromDtoSave();
                this.customerRepository.Save(customer);
                result.Success = true;
                result.Message = "El cliente ha sido agregado correctamente.";

                this.logger.LogInformation(result.Message, result);


            }
            catch (CustomerException sdex)
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

        public ServiceResult UpdateCustomer(CustomerUpdateDto updateDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                if (string.IsNullOrEmpty(updateDto.CompanyName))
                {
                    result.Success = false;
                    result.Message = "El nombre es requerido";
                    return result;
                }

                if (updateDto.CompanyName.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La logitud del nombre es inválida";
                    return result;
                }

                if (string.IsNullOrEmpty(updateDto.ContactName))
                {
                    result.Success = false;
                    result.Message = "El contacto es requerido";
                    return result;
                }
                if (updateDto.CompanyName.Length > 50)
                {
                    result.Success = false;
                    result.Message = "La logintud del contacto es inválida";
                    return result;
                }

                if (!updateDto.EnrollmentDate.HasValue)
                {
                    result.Success = false;
                    result.Message = "La fecha de inicio es requerida.";
                    return result;

                }

                Customer customer = this.customerRepository.GetEntity(updateDto.CustomerId);
                customer.ModifyDate = updateDto.ModifyDate;
                customer.UserMod = updateDto.ModifyUser;
                customer.CompanyName = updateDto.CompanyName;
                customer.ContactName = updateDto.ContactName;
                customer.EnrollmentDate = updateDto.EnrollmentDate;

                this.customerRepository.Update(customer);
                result.Success = true;
                result.Message = "El cliente ha sido actualizado correctamente.";

            }
            catch (CustomerException sdex)
            {
                result.Message = sdex.Message;
                result.Success = false;
                this.logger.LogError(result.Message, sdex.ToString());
            }
            catch (Exception ex)
            {

                result.Message = "Ocurrió un error actualizando el cliente";
                result.Success = false;
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }
            return result;
        }
    }
}