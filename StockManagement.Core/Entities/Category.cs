namespace StockManagement.Core.Entities
{
    public class Category(string name, Guid createdBy) : Entity(createdBy)
    {
        public string Name { get; set; } = name;
    }
}
