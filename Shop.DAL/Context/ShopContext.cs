using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entities;

namespace Shop.DAL.Context
{
    public class ShopContext : DbContext
    {
        internal readonly object Shop;

        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        #region Employee
        public DbSet<Employee>? Employees { get; set; }
        #endregion
    }
}