using Domain.Menus;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models.Read;

[PrimaryKey(nameof(OrderId), nameof(MenuItemId))]
public sealed class OrderMenuItemReadModel
{
    public Guid OrderId { get; set; }
    public OrderReadModel Order { get; set; }

    public Guid MenuItemId { get; set; }
    public MenuItemReadModel MenuItem { get; set; }
}
