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


namespace shop.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ILogger<CustomerService> logger;

        public CustomerService(ICustomerRepository customerRepository,
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
                var customers = this.customerRepository.GetEntities();

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

                result.Data = customer;
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
            ServiceResult result = new ServiceResult();

            try
            {
                Customer customer = saveDto.GetCustomerEntityFromDtoSave();
                customer.address = "Una calle";
                customer.city = "Santo Domingo";
                customer.fax = "8099088978";
                customer.email = "test@test.com";
                customer.phone = "829-804-8998";
                customer.contacttitle = "Sr.";
                customer.country = "Haiti";
                customer.region = "Saint Domingue";
                customer.contactname = "Jose";
                this.customerRepository.Save(customer);
                this.customerRepository.SaveChanges();
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
                customer.email = updateDto.ContactName;
                customer.fax = updateDto.CompanyName;

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