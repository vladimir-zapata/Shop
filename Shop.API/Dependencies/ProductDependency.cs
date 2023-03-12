using Microsoft.Extensions.DependencyInjection;
using Shop.BLL.Contract;
using Shop.BLL.Services;
using Shop.DAL.Interfaces;
using Shop.DAL.Repositories;

namespace Shop.API.Dependencies
{
    public static class ProductDependency
    {
        public static void AddProductDependencies(this IServiceCollection services) 
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
