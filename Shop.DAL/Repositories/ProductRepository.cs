using Microsoft.Extensions.Logging;
using Shop.DAL.Context;
using Shop.DAL.Core;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;

namespace Shop.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly ShopContext _shopContext;
        private readonly ILogger _logger;

        public ProductRepository(ShopContext shopContext, ILogger<IProductRepository> logger) : base (shopContext)
        {
            this._shopContext = shopContext;
            this._logger = logger;
        }

    }
}
