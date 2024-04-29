using Domain.Shared;

namespace Domain.Menus;

public sealed class MenuCategory : Entity
{
    public string Name { get; set; }
    public IEnumerable<MenuItem> Items { get; set; } = Enumerable.Empty<MenuItem>();
    public Guid MenuId { get; set; }
    public Menu Menu { get; set; }
}
