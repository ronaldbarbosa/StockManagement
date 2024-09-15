namespace StockManagement.Application.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public Dictionary<string, string> Claims { get; set; } = [];
    }
}
