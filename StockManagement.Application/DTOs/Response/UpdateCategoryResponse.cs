using System.ComponentModel.DataAnnotations;

namespace StockManagement.Application.DTOs.Response
{
    public class UpdateCategoryResponse : ResponseBase
    {
        [Display(Name = "Categoria")]
        public CategoryDTO? Category { get; set; }
    }
}
