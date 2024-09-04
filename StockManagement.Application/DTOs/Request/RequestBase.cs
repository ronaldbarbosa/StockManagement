namespace StockManagement.Application.DTOs.Request
{
    public class RequestBase
    {
        public Guid UserId { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
