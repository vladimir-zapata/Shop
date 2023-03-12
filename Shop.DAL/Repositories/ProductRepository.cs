using Microsoft.Extensions.Logging;
using Shop.DAL.Context;
using Shop.DAL.Core;
using Shop.DAL.Entities;
using Shop.DAL.Exceptions;
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
            try
            {
                List<Product> products = this._shopContext.Products.Where(pro => !pro.Deleted).ToList();
                return products;
            }
            catch (ProductDataException)
            {
                throw new ProductDataException("Ha ocurrido un error al listar los productos");
            }
        }

        public override Product GetEntity(int id)
        {
            try
            {
                return this._shopContext.Products.FirstOrDefault(pro => pro.ProductId == id && !pro.Deleted);
            }
            catch (ProductDataException)
            {
                throw new ProductDataException("Ha ocurrido un error al obtener el producto");
            }
        }
    }
}
