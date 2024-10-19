namespace StockManagement.Domain.Entities
{
    public class SystemResource
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public List<SystemResource> Children { get; set; } = [];
        public string Path { get; set; }
        public string Icon { get; set; }

        public SystemResource()
        {            
        }

        public SystemResource(Guid id, string name, Guid? parentId, string path, string icon)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            Path = path;
            Icon = icon;
        }
    }
}
