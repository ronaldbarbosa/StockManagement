using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockManagement.Domain.Entities;

namespace StockManagement.Data.EntityConfig
{
    public class LabelConfig : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder.ToTable("Label");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SystemName)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            builder.Property(x => x.Value)
                .IsRequired();

            builder.Property(x => x.Language)
                .IsRequired()
                .HasConversion<int>();
        }
    }
}
