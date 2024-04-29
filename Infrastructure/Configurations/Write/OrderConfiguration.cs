using Domain.Menus;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Write;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.GrossPrice).HasPrecision(8, 2);
        builder.Property(o => o.NetPrice).HasPrecision(8, 2);
    }
}
