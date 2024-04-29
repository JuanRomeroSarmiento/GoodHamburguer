using Domain.Menus;

namespace Infrastructure.Models.Read;

public class MenuCategoryReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<MenuItemReadModel> Items { get; set; }
    public Guid MenuId { get; set; }
    public MenuReadModel Menu { get; set; }
}
