using Domain.Menus;
using Domain.Orders;

namespace Infrastructure.Models.Read;

public class MenuItemReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid MenuCategoryId { get; set; }
    public MenuCategoryReadModel MenuCategory { get; set; }
    public IEnumerable<OrderMenuItemReadModel> OrderMenuItems { get; set; }
}
