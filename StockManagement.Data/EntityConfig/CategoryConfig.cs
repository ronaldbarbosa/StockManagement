using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Core.Entities;

namespace StockManagement.Data.EntityConfig
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.CreatedBy)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedBy)
                .IsRequired(false)
                .HasColumnType("UNIQUEIDENTIFIER");

            builder.Property(x => x.UpdatedAt)
                .IsRequired(false);
        }
    }
}
