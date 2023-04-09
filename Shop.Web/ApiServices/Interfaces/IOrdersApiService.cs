using Shop.Web.Models.Response.Orders;
using Shop.Web.ViewModels.Orders;
using System.Threading.Tasks;

namespace Shop.Web.ApiServices.Interfaces
{
    public interface IOrdersApiService
    {
        Task<OrdersListResponse> GetOrders();
        Task<OrdersResponse> GetOrder(int id);
        Task<OrdersResponse> SaveOrder(CreateOrdersViewModel createOrdersViewModel);
        Task<OrdersResponse> EditOrder(UpdateOrdersViewModel updateOrdersViewModel);
        Task<OrdersResponse> DeleteOrder(DeleteOrdersViewModel deleteOrdersViewModel);
    }
}