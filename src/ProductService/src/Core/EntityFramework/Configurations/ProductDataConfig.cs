using Core.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.EntityFramework.Configurations;

public class ProductDataConfig : IEntityTypeConfiguration<ProductData>
{
    public void Configure(EntityTypeBuilder<ProductData> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.Name).IsUnique();

        builder.Property(p => p.Price).HasColumnType("decimal(19,4)");
    }
}