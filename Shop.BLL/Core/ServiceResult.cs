
namespace Shop.BLL.Core
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public dynamic? Data { get; set; }
        public ServiceResult()
        {
            Success = true;
        }
    }
}