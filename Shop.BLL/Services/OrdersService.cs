using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using Microsoft.Extensions.Logging;
using Shop.BLL.Contract;
using Shop.BLL.Core;
using Shop.BLL.Dtos;
using Shop.BLL.Extentions;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;


namespace Shop.BLL.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ILogger<OrdersService> _logger;
        private readonly IOrdersValidation _ordersValidator;

        public OrdersService(IOrdersRepository ordersRepository, IOrdersValidation ordersValidation, ILogger<OrdersService> logger) 
        {

            _ordersRepository = ordersRepository;
            this._logger = logger;
            _ordersValidator = ordersValidation;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this._logger.LogInformation("Consultando ordenes...");
                
                var orders = _ordersRepository.GetEntities().Where(x => x.Deleted == false).Select(x => x.GetOrdersModelFromAnOrder()).ToList();

                result.Data = orders;
                _logger.LogInformation("Se han consultado las ordenes.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las ordenes.";
                _logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetBbyID(int Id)
        {
            ServiceResult result = new ServiceResult();

            var IsThisAValidID = _ordersValidator.ValidateGetOrdersById(Id);

            if (IsThisAValidID != null) return IsThisAValidID;

            try
            {
                _logger.LogInformation("Consultando orden con el ID ingresado");

                Orders orders = _ordersRepository.GetEntity(Id);

                if (orders == null || orders.Deleted)
                {
                    result.Success = false;
                    result.Message = "No se encontró la orden con este ID";
                }
                else
                {
                    var ordersModel = orders.GetOrdersModelFromAnOrder();

                    result.Data = ordersModel;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la orden con este ID.";
                _logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult SaveOrder(OrdersAddDto ordersAdd)
        {
            ServiceResult result = new ServiceResult();

            Orders orders = ordersAdd.GetOrdersFromOrdersAddDto();

            var IsThisAValidOrder = _ordersValidator.ValidateOrdersToSave(orders);

            if (IsThisAValidOrder != null) return IsThisAValidOrder;

            try
            {
                this._ordersRepository.Save(orders);
                this._ordersRepository.SaveChanges();
                result.Success = true;
                result.Message = "La orden ha sido agregada correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error agregando la orden.";
                _logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult UpdateOrder(OrdersUpdateDto ordersUpdate)
        {
            ServiceResult result = new ServiceResult();

            var orderss = ordersUpdate.GetOrdersFromOrdersUpdateDto();

            var IsAValidOrderToModify = _ordersValidator.ValidateOrdersToUpdate(orderss);

            if (IsAValidOrderToModify != null) return IsAValidOrderToModify;

            try
            {
                Orders order = this._ordersRepository.GetEntity(ordersUpdate.OrderID);

                order.CustomerID = ordersUpdate.CustomerID;
                order.EmployeeID = ordersUpdate.EmployeeID;
                order.ShipperID = ordersUpdate.ShipperID;
                order.Freight = ordersUpdate.Freight;
                order.ShipName = ordersUpdate.ShipName;
                order.ShipAddress = ordersUpdate.ShipAddress;
                order.ShipCity = ordersUpdate.ShipCity;
                order.ShipRegion = ordersUpdate.ShipRegion;
                order.ShipPostalCode = ordersUpdate.ShipPostalCode;
                order.ShipCountry = ordersUpdate.ShipCountry;
                order.OrderDate = ordersUpdate.OrderDate;
                order.ShippedDate = ordersUpdate.ShippedDate;
                order.RequiredDate = ordersUpdate.RequiredDate;
                order.CreationDate = DateTime.Now;
                order.CreationUser = ordersUpdate.RequestUser;

                this._ordersRepository.Update(order);
                this._ordersRepository.SaveChanges();

                result.Success = true;
                result.Message = "Orden modificada correctamente.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error modificando la orden.";
                _logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult RemoveOrder(OrdersRemoveDto removeOrder)
        {
            ServiceResult result = new ServiceResult();

            var IsValidOrder = _ordersValidator.ValidateOrdersToDelete(removeOrder);

            if (IsValidOrder != null) return IsValidOrder;

            try
            {
                Orders order = _ordersRepository.GetEntity(removeOrder.OrderID);
                order.DeleteUser = removeOrder.RequestUser;
                order.DeleteDate = DateTime.Now;
                order.Deleted = true;
                
                this._ordersRepository.Update(order);
                this._ordersRepository.SaveChanges();

                result.Message = "Orden eliminada correctamente.";
            }
            catch (Exception ex)
            {
                result.Message = "Error removiendo la orden.";
                result.Success = false;
                _logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
