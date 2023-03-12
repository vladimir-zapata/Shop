
using Shop.BLL.Core;
using Shop.BLL.Dtos;

namespace Shop.BLL.Contract
{
    public interface IOrdersService : IBaseService
    {
        ServiceResult SaveOrder(OrdersAddDto orders);
        ServiceResult UpdateOrder(OrdersUpdateDto orders);
        ServiceResult RemoveOrder(OrdersRemoveDto orders);
    }
}
