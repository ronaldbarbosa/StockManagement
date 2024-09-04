using StockManagement.Domain.Entities;

namespace StockManagement.Application.DTOs
{
    public class EntityDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }

        public EntityDTO()
        {            
        }

        public EntityDTO(Guid id, DateTime createdAt, DateTime? updatedAt, Guid createdBy, Guid? updatedBy)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            CreatedBy = createdBy;
            UpdatedBy = updatedBy;
        }

        public static explicit operator EntityDTO(Entity entity)
        {
            return new EntityDTO() {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
                CreatedBy = entity.CreatedBy,
                UpdatedBy = entity.UpdatedBy
            };
        }

        public static explicit operator Entity(EntityDTO entityDTO)
        {
            return new Entity(entityDTO.CreatedBy)
            {
                CreatedAt = entityDTO.CreatedAt,
                UpdatedAt = entityDTO.UpdatedAt,
                CreatedBy = entityDTO.CreatedBy,
                UpdatedBy = entityDTO.UpdatedBy
            };
        }
    }
}
