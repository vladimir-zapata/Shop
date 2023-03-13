using Shop.BLL.Dtos;
using Shop.DAL.Entities;
using System;

namespace Shop.BLL.Extentions
{
    public static class CustomerExtention
    {
      

        public static Customer GetCustomerEntityFromDtoSave(this CustomerSaveDto saveDto)
        {
            Customer customer = new Customer()
            {
                CompanyName = saveDto.CompanyName,
                CreationDate = saveDto.CreationDate,
                CreationUser = saveDto.CreationUser,
                ContactName = saveDto.ContactName,
                EnrollmentDate = saveDto.EnrollmentDate
            };

            return customer;
        }
    }
}
