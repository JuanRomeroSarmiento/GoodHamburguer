using Domain.Menus;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class MenuRepository(ApplicationWriteDbContext dbContext) : IMenuRepository
{
    public async Task<IEnumerable<MenuItem>> GetAllByIdAsync(Guid id)
    {
        return await dbContext.MenuItems
            .Where(mi => mi.Category.MenuId == id)
            .ToListAsync();
    }

    public async Task<IEnumerable<MenuItem>> GetByCategoryIdAsync(Guid id)
    {
        return await dbContext.MenuItems
            .Where(mi => mi.Category.Id == id)
            .ToListAsync();
    }
}
