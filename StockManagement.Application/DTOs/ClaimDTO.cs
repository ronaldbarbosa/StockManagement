namespace StockManagement.Application.DTOs
{
    public class ClaimDTO
    {
        public int Id { get; set; }
        public Guid RoleId { get; set; }
        public string Type { get; set; } = SystemResourceType;
        public string Value { get; set; } = string.Empty;

        public static string SystemResourceType => "SystemResource";
    }

}
