using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.BLL.Exceptions
{
    public class OrdersException : Exception
    {
        public OrdersException(string message) : base(message) 
        { 
        
        }
    }
}
