using Shop.DAL.Entities;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Shop.DAL.Core;

namespace Shop.DAL.Context
{
    public class ShopContext : DbContext 
    {
        public DbSet<Customer>? Customers { get; set; }
    }
}
