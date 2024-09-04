using StockManagement.Domain.Entities;

namespace StockManagement.Application.DTOs
{
    public class CategoryDTO : EntityDTO
    {
        public string Name { get; set; } = string.Empty;

        public CategoryDTO()
        {            
        }

        public CategoryDTO(Guid id, DateTime createdAt, DateTime? updatedAt, Guid createdBy, Guid? updatedBy, string name) 
            : base(id, createdAt, updatedAt, createdBy, updatedBy)
        {
            Name = name;
        }

        public static explicit operator CategoryDTO(Category category)
        {
            return new CategoryDTO(
                category.Id, 
                category.CreatedAt, 
                category.UpdatedAt, 
                category.CreatedBy, 
                category.UpdatedBy, 
                category.Name);
        }

        public static explicit operator Category(CategoryDTO categoryDTO)
        {
            return new Category(categoryDTO.Name, categoryDTO.CreatedBy)
            {
                CreatedAt = categoryDTO.CreatedAt,
                UpdatedAt = categoryDTO.UpdatedAt,
                UpdatedBy = categoryDTO.UpdatedBy
            };
        }
    }
}
