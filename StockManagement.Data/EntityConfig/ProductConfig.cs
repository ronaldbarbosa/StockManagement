using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;

namespace StockManagement.Data.EntityConfig
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.SKU)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.UnitOfMeasurement)
                .IsRequired()
                .HasColumnType("SMALLINT");

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

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
