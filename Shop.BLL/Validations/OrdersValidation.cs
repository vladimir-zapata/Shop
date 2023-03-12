using Shop.BLL.Contract;
using Shop.BLL.Core;
using Shop.BLL.Dtos;
using Shop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.BLL.Validations
{
    public class OrdersValidation : IOrdersValidation
    {
        public ServiceResult? ValidateGetOrdersById(int id)
        {
            ServiceResult result = new ServiceResult();

            if (id == 0 || id < 0)
            {
                result.Success = false;
                result.Message = "Introduzca un ID de orden valido.";
                return result;
            }

            return null;
        }
        
        public ServiceResult? ValidateOrders(Orders orders)
        {
            ServiceResult result = new ServiceResult();

            if (orders.EmployeeID == 0 ||  orders.EmployeeID == null)
            {
                result.Success = false;
                result.Message = "Ingrese un employee ID valido.";
                return result;
            }
            if (orders.ShipperID == 0 || orders.ShipperID == null)
            {
                result.Success = false;
                result.Message = "Ingrese un shipper ID valido.";
                return result;
            }
            if (orders.Freight == 0 || orders.Freight == null)
            {
                result.Success = false;
                result.Message = "Ingrese un precio de freight valido.";
                return result;
            }
            if (string.IsNullOrEmpty(orders.ShipName))
            {
                result.Success = false;
                result.Message = "El shipname es requerido.";
                return result;
            }
            if (string.IsNullOrEmpty(orders.ShipAddress))
            {
                result.Success = false;
                result.Message = "La direccion es requerida";
                return result;
            }
            if (string.IsNullOrEmpty(orders.ShipCity))
            {
                result.Success = false;
                result.Message = "La ciudad es requerida";
                return result;
            }
            if (string.IsNullOrEmpty(orders.ShipCountry))
            {
                result.Success = false;
                result.Message = "El pais es requerido.";
                return result;
            }
            return null;
        }

        public ServiceResult? ValidateOrdersToSave(Orders orders)
        {
            ServiceResult result = new ServiceResult();
            var IsThisOrderValid = ValidateOrders(orders);

            if(IsThisOrderValid != null)  return IsThisOrderValid;

            if (orders.CreationUser == 0 || orders.CreationUser < 0)
            {
                result.Success = false;
                result.Message = "Ingrese un usuario de solicitud valido";
                return result;
            }

            return null;
        }

        public ServiceResult? ValidateOrdersToUpdate(Orders orders)
        {
            ServiceResult result = new ServiceResult();
            var IsThisOrderValid = ValidateOrders(orders);

            if (IsThisOrderValid != null) return IsThisOrderValid;

            if (orders.OrderID == 0 || orders.OrderID == null)
            {
                result.Success = false;
                result.Message = "Ingrese un ID de orden valido.";
                return result;
            }

            if (orders.ModifyUser == 0 || orders.ModifyUser < 0)
            {
                result.Success = false;
                result.Message = "Ingrese un numero de usuario valido.";
                return result;
            }

            return null;
        }

        public ServiceResult? ValidateOrdersToDelete(OrdersRemoveDto orderstoDelete)
        {
            ServiceResult result = new ServiceResult();

            if (orderstoDelete.OrderID == 0 || orderstoDelete.OrderID < 0)
            {
                result.Success = false;
                result.Message = "Ingrese un ID de orden valido.";
                return result;
            }

            if (orderstoDelete.RequestUser == 0 || orderstoDelete.RequestUser < 0)
            {
                result.Success = false;
                result.Message = "Ingrese un numero de usuario valido";
                return result;
            }

            return null;
        }
    }
}
