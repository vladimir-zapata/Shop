using Microsoft.Extensions.DependencyInjection;
using Shop.BLL.Services;
using Shop.DAL.Interfaces;
using Shop.DAL.Repositories;
using Shop.BLL.Contract;
using Shop.BLL.Validations;

namespace Shop.API.Dependencies
{
    public static class OrdersDependencies
    {
            public static void AddOrdersDependency(this IServiceCollection services)
            {
                services.AddScoped<IOrdersRepository, OrdersRepository>();
                services.AddScoped<IOrdersValidation, OrdersValidation>();
                services.AddTransient<IOrdersService, OrdersService>();
            }
    }
}
