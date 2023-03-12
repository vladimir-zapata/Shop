using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Shop.DAL.Context;
using Shop.DAL.Interfaces;
using Shop.DAL.Repositories;
using Shop.BLL.Services;
using Shop.BLL.Contract;
using Shop.API.Dependencies;

namespace Shop.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Context
            services.AddDbContext<ShopContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("ShopContext")));

            // Dependencias //
            services.AddOrdersDependency();
            // Repositories //
            //services.AddTransient<IOrdersRepository, OrdersRepository>();

            // APP Services //
            //services.AddTransient<IOrdersService, OrdersService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shop.API", Version = "v1" });
            });
        }
            

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
