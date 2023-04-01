using Shop.DAL.Model;
using System.Collections.Generic;

namespace Shop.Web.Models.Response.Employees
{
    public class EmployeeListResponse
    {
        public bool Success { get; set; }
        public List<EmployeeModel> Data { get; set; }
        public string Message { get; set; }
    }
}
