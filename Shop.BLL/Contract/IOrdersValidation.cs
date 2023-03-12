using Shop.BLL.Core;
using Shop.BLL.Dtos;
using Shop.DAL.Entities;

namespace Shop.BLL.Contract
{
    public interface IOrdersValidation
    {
        ServiceResult? ValidateGetOrdersById(int id);

        ServiceResult? ValidateOrders(Orders orders);

        ServiceResult? ValidateOrdersToSave(Orders orders);

        ServiceResult? ValidateOrdersToUpdate(Orders orders);

        ServiceResult? ValidateOrdersToDelete(OrdersRemoveDto orders);

    }
}