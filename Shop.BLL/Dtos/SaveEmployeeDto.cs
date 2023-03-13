using Shop.BLL.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.BLL.Dtos
{
    public class SaveEmployeeDto : DtoBase
    {
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }

        public string EmployeeLastName { get; set; }
    }
}
