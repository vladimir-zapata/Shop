using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Shop.API.Request
{
    public abstract class RequestBase
    {
        public int RequestUser { get; set; }
    }
}
