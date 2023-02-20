namespace Shop.API.Controllers
{
    public class ModifyUserRequest
    {
        public string Email { get; internal set; }
        public string Name { get; internal set; }
        public int UserId { get; internal set; }
    }
}