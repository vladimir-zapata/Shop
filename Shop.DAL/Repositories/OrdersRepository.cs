using System.Collections.Generic;
using Shop.DAL.Entities;
using Shop.DAL.Context;
using Microsoft.Extensions.Logging;
using Shop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Shop.DAL.Core;

namespace Shop.DAL.Repositories
{
    public class OrdersRepository : RepositoryBase<Orders>, IOrdersRepository
    {
        private readonly ShopContext _ordersContext;
        private readonly ILogger _logger;

        public OrdersRepository(ShopContext ordersContext, ILogger<IOrdersRepository> logger) : base(ordersContext)
        {
            this._ordersContext = ordersContext;
            this._logger = logger;
        }

    }
}
