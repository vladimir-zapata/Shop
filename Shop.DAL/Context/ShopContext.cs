using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entities;

namespace Shop.DAL.Context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            
        }
        #region "Ordenes"
            public DbSet<Orders> Orders { get; set; }
        #endregion
    }
}
