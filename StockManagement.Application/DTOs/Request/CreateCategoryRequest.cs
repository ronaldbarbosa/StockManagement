using System.ComponentModel.DataAnnotations;

namespace StockManagement.Application.DTOs.Request
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
