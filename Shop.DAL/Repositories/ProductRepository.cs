using Microsoft.Extensions.Logging;
using Shop.DAL.Context;
using Shop.DAL.Core;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly ShopContext _productContext;
        private readonly ILogger _logger;

        public ProductRepository(ShopContext productContext, ILogger<IProductRepository> logger) : base (productContext)
        {
            this._productContext = productContext;
            this._logger = logger;
        }

    }
}
