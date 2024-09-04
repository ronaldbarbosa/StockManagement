using System.ComponentModel.DataAnnotations;

namespace StockManagement.Application.DTOs.Response
{
    public class Error(string property, string message)
    {
        [Display(Name = "Propriedade")]
        public string Property { get; set; } = property;
        [Display(Name = "Mensagem")]
        public string Message { get; set; } = message;
    }
}
