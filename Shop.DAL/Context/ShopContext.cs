using Microsoft.EntityFrameworkCore;
using Shop.DAL.Entities;

namespace Shop.DAL.Context
{
    public class ShopContext : DbContext
    {

        #region "Ordenes"
            public DbSet<Orders> Orders { get; set; }
        #endregion
    }
}
