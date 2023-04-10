using Shop.BLL.Core;
using Shop.BLL.Dtos;

namespace Shop.BLL.Contract
{
    public interface ICustomerService : IBaseService
    {
        ServiceResult SaveCustomer(CustomerSaveDto saveDto);
        ServiceResult UpdateCustomer(CustomerUpdateDto updateDto);
        ServiceResult RemoveCustomer(CustomerRemoveDto removeDto);

        
      
    }
}
