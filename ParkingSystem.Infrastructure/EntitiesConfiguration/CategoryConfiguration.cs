using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingSystem.Domain.Entities;

namespace ParkingSystem.Infrastructure.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
        builder.Property(p => p.PriceTableId).IsRequired();
        builder.HasOne(c => c.PriceTable).WithOne(pt => pt.Category).HasForeignKey<Category>(c => c.PriceTableId);
    }
}
