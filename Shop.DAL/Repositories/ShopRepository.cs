using Shop.DAL.Context;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL.Repositories
{
    public class ShopRepository : Core.RepositoryBase<ShopContext>, ShopRepository
    {
        private readonly ShopContext _Shopcontext;
        private readonly ILogger<ShopRepository> _logger;
        public ShopRepository(ShopContext shopContext, ILogger<ShopRepository> logger) : base(shopContext)
        {
            _Shopcontext = shopContext;
            _logger = logger;
        }
        public override List<ShopContext> GetShop()
        {
            var shop = this._Shopcontext.Shop.where(shop => !shop.deleted).ToList();
            return shop;
     
        }
    }

}
