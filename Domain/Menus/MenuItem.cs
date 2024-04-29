using Domain.Orders;
using Domain.Shared;

namespace Domain.Menus;

public sealed class MenuItem : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Guid MenuCategoryId { get; set; }
    public MenuCategory Category { get; set; }
    public IEnumerable<OrderMenuItem> OrderMenuItems { get; set; }

    public MenuItem(
        Guid id, 
        string name, 
        decimal price, 
        Guid menuCategoryId)
    {
        Id = id;
        Name = name;
        Price = price;
        MenuCategoryId = menuCategoryId;
    }
}
