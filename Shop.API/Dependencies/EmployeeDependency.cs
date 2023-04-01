using Microsoft.Extensions.DependencyInjection;
using Shop.BLL.Contract;
using Shop.BLL.Services;
using Shop.DAL.Interfaces;
using Shop.DAL.Repositories;

namespace Shop.API.Dependencies
{
    public static class EmployeeDependency
    {
        public static void AddEmployeeDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }

}
