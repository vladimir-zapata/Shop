namespace Shop.Web.Models.Response
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }

    }
}
