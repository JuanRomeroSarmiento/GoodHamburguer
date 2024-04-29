using Domain.Shared;

namespace Domain.Menus;

public sealed class Menu : Entity
{
    public string Name { get; set; }
    public IEnumerable<MenuCategory> Categories { get; set; } = Enumerable.Empty<MenuCategory>();
}
