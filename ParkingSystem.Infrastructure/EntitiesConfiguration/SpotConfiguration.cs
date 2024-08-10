using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingSystem.Domain.Entities;

namespace ParkingSystem.Infrastructure.EntitiesConfiguration;

public class SpotConfiguration : IEntityTypeConfiguration<Spot>
{
    public void Configure(EntityTypeBuilder<Spot> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Number).IsRequired();
        builder.Property(p => p.IsOccupied).HasDefaultValue(false);
        builder.Property(p => p.CategoryId).IsRequired();
        builder.HasOne(e => e.Category).WithMany(e => e.Spots).HasForeignKey(e => e.CategoryId);
    }
}