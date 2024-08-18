using StockManagement.Core.Enums;

namespace StockManagement.Core.Entities
{
    public class Product : Entity
    {
        public string SKU { get; private set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; } = UnitOfMeasurement.None;

        public Product() : base(Guid.Empty)
        {
        }

        public Product(string name, string description, Guid createdBy, Guid categoryId, Category? category = null, UnitOfMeasurement unitOfMeasurement = UnitOfMeasurement.None) 
            : base(createdBy)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Category = category;
            UnitOfMeasurement = unitOfMeasurement;
            SKU = SKUGenerator();
        }

        private string SKUGenerator()
        {
            return $"{Name.ToUpper()}";
        }
    }
}
