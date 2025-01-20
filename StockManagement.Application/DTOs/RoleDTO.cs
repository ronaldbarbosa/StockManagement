namespace StockManagement.Application.DTOs
{
    public class RoleDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NormalizedName { get; set; } = string.Empty;
        public int TotalUsers { get; set; }
        public List<ClaimDTO> Claims { get; set; } = [];
    }
}
