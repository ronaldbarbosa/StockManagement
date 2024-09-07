using System.ComponentModel.DataAnnotations;

namespace StockManagement.Application.DTOs.Request
{
    public class UpdateCategoryRequest : RequestBase
    {
        public Guid Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;
    }
}
