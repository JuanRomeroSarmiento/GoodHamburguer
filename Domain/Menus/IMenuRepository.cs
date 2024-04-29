namespace Domain.Menus;

public interface IMenuRepository
{
    Task<IEnumerable<MenuItem>> GetAllByIdAsync(Guid id);

    Task<IEnumerable<MenuItem>> GetByCategoryIdAsync(Guid id);
}
