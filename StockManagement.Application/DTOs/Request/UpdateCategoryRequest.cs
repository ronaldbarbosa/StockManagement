namespace StockManagement.Application.DTOs.Request
{
    public class UpdateCategoryRequest : RequestBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
