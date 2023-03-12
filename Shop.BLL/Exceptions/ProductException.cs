using System;

namespace Shop.BLL.Exceptions
{
    public class ProductException : Exception
    {
        public ProductException(string message) : base(message) {}
    }
}
