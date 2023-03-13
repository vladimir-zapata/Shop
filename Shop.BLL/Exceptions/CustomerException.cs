using System;


namespace Shop.BLL.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException(string message) : base(message)
        {
            // usted agregar x logica: Enviar una notificacion, persistir local file system, bd, etc.//
        }
    }
}
