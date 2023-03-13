using Shop.BLL.Core;
using Shop.BLL.Dtos;

namespace Shop.BLL.Contract
{
    public interface ICustomerService : IBaseService
    {
        ServiceResult SaveCustomer(CustomerSaveDto saveDto);
        ServiceResult RemoveCustomer(CustomerRemoveDto removeDto);
        ServiceResult UpdateCustomer(CustomerUpdateDto updateDto);
    }
}
