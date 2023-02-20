namespace Shop.API.Request.Employee
{
    public abstract class EmployeeRequest : RequestBase
    {
        public int EmployeeId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
