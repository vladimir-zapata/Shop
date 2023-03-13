using System;

namespace Shop.BLL.Exceptions
{
    public class EmployeeException : Exception
    {
        public EmployeeException(string message) : base(message) { }
    }
}
