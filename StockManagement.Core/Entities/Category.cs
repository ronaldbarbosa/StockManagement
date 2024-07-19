namespace StockManagement.Core.Entities
{
    public class Category(string name, Guid createdBy) : EntityBase(createdBy)
    {
        public string Name { get; set; } = name;
    }
}
