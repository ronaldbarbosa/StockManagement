namespace StockManagement.Domain.Entities
{
    public class Entity(Guid createdBy)
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime CreatedAt { get; init; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public Guid CreatedBy { get; init; } = createdBy;
        public Guid? UpdatedBy { get; set; }
    }
}
