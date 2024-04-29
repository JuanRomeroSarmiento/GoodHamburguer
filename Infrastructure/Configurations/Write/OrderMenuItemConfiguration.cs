using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations.Write;

internal class OrderMenuItemConfiguration : IEntityTypeConfiguration<OrderMenuItem>
{
    public void Configure(EntityTypeBuilder<OrderMenuItem> builder)
    {
        builder.HasKey(omi => new {omi.OrderId, omi.MenuItemId});
    }
}
