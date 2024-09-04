using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StockManagement.Application.DTOs.Response
{
    public class GetCategoryByIdResponse : ResponseBase
    {
        [Display(Name = "Categoria")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CategoryDTO? Category { get; set; }
    }
}
