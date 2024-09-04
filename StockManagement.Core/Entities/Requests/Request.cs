namespace StockManagement.Domain.Entities.Requests
{
    public class Request<TData>
    {
        public TData? Data { get; set; }
    }
}
