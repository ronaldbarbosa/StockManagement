namespace StockManagement.Core.Entities.Requests
{
    public class PagedRequest
    {
        public int PageCount { get; set; } = Configuration.DefaultPageCount;
        public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
    }
}
