using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingSystem.Infrastructure.EntitiesConfiguration;

public class PriceTableConfiguration : IEntityTypeConfiguration<PriceTable>
{
    public void Configure(EntityTypeBuilder<PriceTable> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.PayPerUse).IsRequired();
        builder.Property(p => p.Subscription).IsRequired();
    }
}
