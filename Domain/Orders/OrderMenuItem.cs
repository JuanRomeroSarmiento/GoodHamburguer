using Domain.Menus;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Domain.Orders;

[PrimaryKey(nameof(OrderId), nameof(MenuItemId))]
public sealed class OrderMenuItem
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; }

    public Guid MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
}
