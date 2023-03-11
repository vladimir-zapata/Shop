using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Shop.BLL.Contract;
using Shop.BLL.Core;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;


namespace Shop.BLL.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersService> logger;

        public OrdersService(IOrdersRepository ordersRepository, 
                                ILogger<OrdersService> logger) 
        {
            this._ordersRepository = ordersRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando ordenes...");
                var orders = this._ordersRepository
                                    .GetEntities()
                                    .Select(ord => new OrdersModel()
                                    {
                                      OrderID = ord.OrderID,
                                      CustomerID = ord.CustomerID,
                                      EmployeeID = ord.EmployeeID,
                                      ShipperID = ord.ShipperID,
                                      Freight = ord.Freight,
                                      ShipName = ord.ShipName,
                                      ShipAddress = ord.ShipAddress,
                                      ShipCity = ord.ShipCity,
                                      ShipRegion = ord.ShipRegion,
                                      ShipPostalCode = ord.ShipPostalCode,
                                      ShipCountry = ord.ShipCountry,
                                      OrderDate = (DateTime)ord.OrderDate,
                                      ShippedDate = (DateTime)ord.ShippedDate
                                    }).ToList();

                result.Data = orders;
                this.logger.LogInformation("Se han consultado las ordenes.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las ordenes.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetBbyID(int Id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("Consultando la orden...");
                var orders = this._ordersRepository.GetEntity(Id);
                OrdersModel ordersModel = new OrdersModel()
                {
                    OrderID = orders.OrderID,
                    CustomerID = orders.CustomerID,
                    EmployeeID = orders.EmployeeID,
                    ShipperID = orders.ShipperID,
                    Freight = orders.Freight,
                    ShipName = orders.ShipName,
                    ShipAddress = orders.ShipAddress,
                    ShipCity = orders.ShipCity,
                    ShipRegion = orders.ShipRegion,
                    ShipPostalCode = orders.ShipPostalCode,
                    ShipCountry = orders.ShipCountry,
                    OrderDate = (DateTime)orders.OrderDate,
                    ShippedDate = (DateTime)orders.ShippedDate
                };
                result.Data = ordersModel;
                this.logger.LogInformation("Se ha consultado la orden.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las ordenes.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
