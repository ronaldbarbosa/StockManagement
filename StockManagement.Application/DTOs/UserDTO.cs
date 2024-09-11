using System.Security.Claims;

namespace StockManagement.Application.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public List<Claim> Claims { get; set; }
    }
}
