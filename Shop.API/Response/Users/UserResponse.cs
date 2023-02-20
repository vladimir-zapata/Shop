namespace Shop.API.Response.User
{
    public class UserResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserId { get; internal set; }
        public string UserName { get; internal set; }
    }
}
