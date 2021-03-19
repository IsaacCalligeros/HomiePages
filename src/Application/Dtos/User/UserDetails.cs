namespace HomiePages.Application.Dtos.User
{
    public class UserDetails
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Role { get; set; }
    }
}
