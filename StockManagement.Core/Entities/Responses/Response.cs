using System.Net;
using System.Text.Json.Serialization;

namespace StockManagement.Core.Entities.Responses
{
    public class Response<TData>
    {
        public HttpStatusCode? StatusCode { get; set; } = HttpStatusCode.OK;
        public TData? Data { get; set; }
        public string? Message { get; set; }
        [JsonIgnore]
        public bool IsSuccess { get; set; }

        public Response(TData? data, string? message = null, HttpStatusCode? statusCode = HttpStatusCode.OK)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
            IsSuccess = statusCode.HasValue && (int)statusCode.Value is >= 200 and <= 299;
        }
    }
}
