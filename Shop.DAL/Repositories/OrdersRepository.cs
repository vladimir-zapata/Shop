using System.Collections.Generic;
using Shop.DAL.Entities;
using Shop.DAL.Context;
using Microsoft.Extensions.Logging;
using Shop.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Shop.DAL.Repositories
{
    public class OrdersRepository : Interfaces.IOrdersRepository
    {
        private readonly ShopContext shopContext;
        private readonly ILogger<IOrdersRepository> logger;

        public OrdersRepository(ShopContext shopContext, 
                                ILogger<IOrdersRepository> logger) 
        {
            this.shopContext = shopContext;
            this.logger = logger;
        }
        public bool Exists(string shipname)
        {
            return this.shopContext.Orders.Any(st => st.ShipName == shipname);
        }

        public List<Orders> GetAll()
        {
            return this.shopContext.Orders.ToList();
        }

        public Orders GetbyId(int orderID)
        {
            return this.shopContext.Orders.Find(orderID);
        }

        public void Remove(Orders orders)
        {
            try
            {
                Orders ordersToRemove = this.GetbyId(orders.OrderID);

                ordersToRemove.Deleted = true;
                ordersToRemove.DeleteDate = DateTime.Now;
                ordersToRemove.DeleteUser = orders.DeleteUser;

                this.shopContext.Orders.Update(ordersToRemove);
                this.shopContext.SaveChanges();
            }
            catch(Exception ex) 
            {
                this.logger.LogError($"Error borrando la orden", ex.ToString());
            }
        }

        public void Save(Orders orders)
        {
            try
            {
                Orders ordersToAdd = new Orders()
                {
                    OrderID = orders.OrderID,
                    CustID = orders.CustID,
                    EmpID = orders.EmpID,
                    CreationDate = DateTime.Now,
                    CreationUser = orders.CreationUser,
                    OrderDate = orders.OrderDate,
                    ShippedDate = orders.ShippedDate,
                    ShipperID = orders.ShipperID,
                    Freight = orders.Freight,
                    ShipName = orders.ShipName,
                    ShipAddress = orders.ShipAddress,
                    ShipCity = orders.ShipCity,
                    ShipRegion = orders.ShipRegion,
                    ShipPostalCode = orders.ShipPostalCode,
                    ShipCountry = orders.ShipCountry,

                };

                this.shopContext.Orders.Add(ordersToAdd);
            }
            catch(Exception ex)
            {
                this.logger.LogError($"Error borrando la orden", ex.ToString());
            }
        }

        public void Update(Orders orders)
        {
            try 
            {
                Orders ordersToUpdate = this.GetbyId(orders.OrderID);

                ordersToUpdate.OrderID = orders.OrderID;
                ordersToUpdate.CustID = orders.CustID;
                ordersToUpdate.EmpID = orders.EmpID;
                ordersToUpdate.ModifyDate = DateTime.Now;
                ordersToUpdate.ModifyUser = orders.ModifyUser;
                ordersToUpdate.OrderDate = orders.OrderDate;
                ordersToUpdate.ShippedDate = orders.ShippedDate;
                ordersToUpdate.ShipperID = orders.ShipperID;
                ordersToUpdate.Freight = orders.Freight;
                ordersToUpdate.ShipName = orders.ShipName;
                ordersToUpdate.ShipAddress = orders.ShipAddress;
                ordersToUpdate.ShipCity = orders.ShipCity;
                ordersToUpdate.ShipRegion = orders.ShipRegion;
                ordersToUpdate.ShipPostalCode = orders.ShipPostalCode;
                ordersToUpdate.ShipCountry = orders.ShipCountry;
                this.shopContext.SaveChanges();

            } 
            catch(Exception ex)
            {
                this.logger.LogError($"Error borrando la orden", ex.ToString());
            }
        }
    }
}
