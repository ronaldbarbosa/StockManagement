using System.ComponentModel.DataAnnotations;

namespace StockManagement.Application.DTOs.Response
{
    public class CreateUserResponse : ResponseBase
    {
        [Display(Name = "Erros")]
        public Dictionary<string, List<string>> Errors { get; set; } = new();

        public bool IsSucceded()
        {
            return Errors.Count == 0;
        }
    }
}
