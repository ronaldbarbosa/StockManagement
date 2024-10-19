using StockManagement.Domain.Entities;
using System.IO;

namespace StockManagement.Application.DTOs
{
    public class SystemResourceDTO()
    {
        public Guid Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public List<SystemResourceDTO> Children { get; set; } = [];
        public string Path { get; set; }
        public string Icon { get; set; }

        public SystemResourceDTO(Guid id, string name, List<SystemResourceDTO>? children, string icon, string? path) : this()
        {
            Id = id;
            Name = name;
            Children = children ?? [];
            Icon = icon;
            Path = path ?? "#";
        }

        public static explicit operator SystemResourceDTO(SystemResource systemResource)
        {
            var children = new List<SystemResourceDTO>();

            if (systemResource.Children is not null && systemResource.Children.Count > 0)
            {
                foreach (var resource in systemResource.Children)
                {
                    children.Add((SystemResourceDTO)resource!);
                }
            }            

            return new SystemResourceDTO()
            {
                Id = systemResource.Id,
                Name = systemResource.Name,
                Children = children,
                Icon = systemResource.Icon,
                Path = systemResource.Path
            };
        }

        public static explicit operator SystemResource(SystemResourceDTO systemResourceDTO)
        {
            return new SystemResource()
            {
                Id = systemResourceDTO.Id,
                Name = systemResourceDTO.Name,
                Icon = systemResourceDTO.Icon,
                Path = systemResourceDTO.Path
            };
        }
    }
}
