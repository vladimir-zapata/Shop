using System;

namespace Shop.DAL.Exceptions
{
    public class ProductDataException : Exception
    {
        public ProductDataException(string message) : base(message)
        {

        }
    }
}
