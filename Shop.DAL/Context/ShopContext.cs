using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entities;

namespace Shop.DAL.Context
{
    public class ShopContext : DbContext
    {
        public DbSet<Customer>? Customers { get; set; }
    }
}
