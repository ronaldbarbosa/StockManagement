using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;

namespace StockManagement.Data.EntityConfig
{
    public class SystemResourceConfig : IEntityTypeConfiguration<SystemResource>
    {
        public void Configure(EntityTypeBuilder<SystemResource> builder)
        {
            builder.ToTable("SystemResource");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.Path)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200)
                .HasDefaultValue("#");

            builder.Property(x => x.Icon)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .HasDefaultValue("");

            builder.HasMany(x => x.Children)
                .WithOne()
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
