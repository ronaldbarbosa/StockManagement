namespace StockManagement.Domain.Entities.Responses
{
    public class PagedResponse<TEntity>
    {
        public List<TEntity> Data { get; set; } = [];
        public int CurrentPage { get; set; } = 0;
        public int TotalPages { get; set; } = 0;
        public int PageCount { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
    }
}
