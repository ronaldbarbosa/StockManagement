namespace StockManagement.Application.DTOs.Request
{
    public class GetCategoryByIdRequest : RequestBase
    {
        public Guid Id { get; set; }
    }
}
