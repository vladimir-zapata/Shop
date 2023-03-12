using Shop.BLL.Dtos;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Shop.BLL.Extentions
{
    public static class OrdersExtention
    {
        public static OrdersModel GetOrdersModelFromAnOrder(this Orders orders)
        {
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
                ShippedDate = (DateTime)orders.ShippedDate,
                RequiredDate = (DateTime)orders.RequiredDate,
            };

            return ordersModel;
        }

        public static Orders GetOrdersFromOrdersAddDto(this OrdersAddDto ordersAdd)
        {
            Orders orders = new Orders()
            {
                CustomerID = ordersAdd.CustomerID,
                EmployeeID = ordersAdd.EmployeeID,
                ShipperID = ordersAdd.ShipperID,
                Freight = ordersAdd.Freight,
                ShipName = ordersAdd.ShipName,
                ShipAddress = ordersAdd.ShipAddress,
                ShipCity = ordersAdd.ShipCity,
                ShipRegion = ordersAdd.ShipRegion,
                ShipPostalCode = ordersAdd.ShipPostalCode,
                ShipCountry = ordersAdd.ShipCountry,
                OrderDate = (DateTime)ordersAdd.OrderDate,
                ShippedDate = (DateTime)ordersAdd.ShippedDate,
                RequiredDate = (DateTime)ordersAdd.RequiredDate,
                CreationUser = ordersAdd.RequestUser,
                CreationDate = DateTime.Now
            };

            return orders;
        }

        public static Orders GetOrdersFromOrdersUpdateDto(this OrdersUpdateDto ordersUpdate)
        {
            Orders orders = new Orders()
            {
                OrderID = ordersUpdate.OrderID,
                CustomerID = ordersUpdate.CustomerID,
                EmployeeID = ordersUpdate.EmployeeID,
                ShipperID = ordersUpdate.ShipperID,
                Freight = ordersUpdate.Freight,
                ShipName = ordersUpdate.ShipName,
                ShipAddress = ordersUpdate.ShipAddress,
                ShipCity = ordersUpdate.ShipCity,
                ShipRegion = ordersUpdate.ShipRegion,
                ShipPostalCode = ordersUpdate.ShipPostalCode,
                ShipCountry = ordersUpdate.ShipCountry,
                OrderDate = (DateTime)ordersUpdate.OrderDate,
                ShippedDate = (DateTime)ordersUpdate.ShippedDate,
                RequiredDate = (DateTime)ordersUpdate.RequiredDate,
                ModifyUser = ordersUpdate.RequestUser,
                ModifyDate = DateTime.Now
            };

            return orders;
        }
    }
}
