using Microsoft.Extensions.Logging;
using Shop.DAL.Context;
using Shop.DAL.Core;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ShopContext shopContext;
        private readonly ILogger ilogger;

        public UserRepository(ShopContext shopContext, ILogger<IUserRepository> ilogger) : base(shopContext)
        {
            this.shopContext = shopContext;
            this.ilogger = ilogger;
        }

    }
}
