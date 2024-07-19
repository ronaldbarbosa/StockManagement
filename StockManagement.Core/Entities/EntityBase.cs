namespace StockManagement.Core.Entities
{
    public abstract class EntityBase(Guid createdBy)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public Guid CreatedBy { get; set; } = createdBy;
        public Guid? UpdatedBy { get; set; }
    }
}
