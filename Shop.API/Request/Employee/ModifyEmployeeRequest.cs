namespace Shop.API.Request.Employee
{
    public class ModifyEmployeeRequest : RequestBase
    {
        public string EmpId { get; set; }
        public string EmployeeName { get; set; }
    }
}
