using Microsoft.Extensions.DependencyInjection;
using Shop.DAL.Interfaces;
using Shop.DAL.Repositories;

namespace Shop.API.Dependencies
{
    public static class EmployeeDependency
    {
        public static void AddEmployeeDependencies(this IServiceCollection services)
        { 
                services.AddScoped<IEmployeeRepository, EmployeeRepository>();
                services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        }
    }

}
