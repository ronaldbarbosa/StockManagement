using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StockManagement.Application.DTOs.Response
{
    public class LoginResponse : ResponseBase
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AccessToken { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RefreshToken { get; set; }

        [Display(Name = "Erros")]
        public Dictionary<string, List<string>> Errors { get; set; } = new();

        public bool IsSucceded()
        {
            return Errors.Count == 0;
        }
    }
}
