using Microsoft.Extensions.Logging;
using Shop.DAL.Context;
using Shop.DAL.Core;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext) : base (shopContext)
        {
            this._shopContext = shopContext;
        }

        public override List<Product> GetEntities() 
        {
            List<Product> products = this._shopContext.Products.Where(pro => !pro.Deleted).ToList(); 
            return products;
        }

        public override Product GetEntity(int id)
        {
            return this._shopContext.Products.FirstOrDefault(pro => pro.ProductId == id && !pro.Deleted);
        }

        public override void Update(Product entity)
        {
            base.Update(entity);
            base.SaveChanges();
        }
    }
}
