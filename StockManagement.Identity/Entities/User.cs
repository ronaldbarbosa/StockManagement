using Microsoft.AspNetCore.Identity;

namespace StockManagement.Identity.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
    }
}
