using System.Net;
using System.Text.Json.Serialization;

namespace StockManagement.Core.Entities.Responses
{
    public class PagedResponse<TData> : Response<TData>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }

        [JsonConstructor]
        public PagedResponse(TData? data, int currentPage, int pageCount, int totalCount) : base(data)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageCount);
            PageCount = pageCount;
            TotalCount = totalCount;
        }

        public PagedResponse(TData? data, string? message, HttpStatusCode statusCode) : base(data, message, statusCode)
        {
        }
    }
}
