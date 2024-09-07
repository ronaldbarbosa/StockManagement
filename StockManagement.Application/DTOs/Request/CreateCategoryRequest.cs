using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StockManagement.Application.DTOs.Request
{
    public class CreateCategoryRequest : RequestBase
    {
        [Display(Name = "Nome")]
        [JsonPropertyName("nome")]
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        [Length(2, 150, ErrorMessage = "O campo nome deve ter no mínimo 2 e no máximo 150 caracteres.")]
        public string Name { get; set; } = string.Empty;
    }
}
