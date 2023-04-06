using Shop.BLL.Core;
using System;

namespace Shop.BLL.Dtos
{
    public class EmployeeDto : DtoBase
    {
        internal DateTime ModifyDate;

        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; } 
        public DateTime HireDate { get; set; }
      //  public object DeleteUser { get; internal set; }
      //  public DateTime DeleteDate { get; internal set; }
       // public bool Deleted { get; internal set; }
    }
}
