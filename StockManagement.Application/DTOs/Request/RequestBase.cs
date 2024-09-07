using System.Text.Json.Serialization;

namespace StockManagement.Application.DTOs.Request
{
    public class RequestBase
    {
        [JsonPropertyName("usuarioId")]
        public Guid UserId { get; set; }
        public DateTime RequestDate { get; private set; } = DateTime.Now;
    }
}
