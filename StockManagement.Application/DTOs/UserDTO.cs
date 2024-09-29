namespace StockManagement.Application.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string? AvatarUrl { get; set; }

        public Dictionary<string, string> Claims { get; set; } = [];

        public UserDTO()
        {            
        }

        //public static explicit operator UserDTO(User user)
        //{
        //    return new UserDTO()
        //    {
        //        Email = user.Email ?? "",
        //        Name = user.Name,
        //        Username = user.UserName ?? ""
        //    };
        //}
    }
}
