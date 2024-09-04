using StockManagement.Domain;

namespace StockManagement.Application.DTOs.Request
{
    public class PagedRequest : RequestBase
    {
        public int PageCount { get; set; } = Configuration.DefaultPageCount;
        public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
    }
}
