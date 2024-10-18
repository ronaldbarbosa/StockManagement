namespace StockManagement.Domain.Entities
{
    public class SystemResource
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public List<SystemResource> Children { get; set; } = [];

        public SystemResource()
        {            
        }

        public SystemResource(Guid id, string name, List<SystemResource> children)
        {
            Id = id;
            Name = name;
            Children = children;
        }
    }
}
