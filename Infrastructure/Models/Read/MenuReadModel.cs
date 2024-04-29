using Domain.Menus;

namespace Infrastructure.Models.Read;

public class MenuReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<MenuCategoryReadModel> Categories { get; set; } = Enumerable.Empty<MenuCategoryReadModel>();
}
