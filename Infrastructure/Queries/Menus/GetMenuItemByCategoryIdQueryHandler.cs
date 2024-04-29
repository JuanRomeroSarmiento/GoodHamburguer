using Application.Menus.GetByCategory;
using Domain.Shared;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries.Menus;

public class GetMenuItemByCategoryIdQueryHandler(
    ApplicationReadDbContext dbContext) 
    : IRequestHandler<GetMenuItemsByCategoryIdQuery, Result<MenuItemsByCategoryResponse>>
{
    public async Task<Result<MenuItemsByCategoryResponse>> Handle(
        GetMenuItemsByCategoryIdQuery request, 
        CancellationToken cancellationToken)
    {
        IEnumerable<MenuItemResponse> menuItemList = await dbContext.MenuItems
            .Where(mi => mi.MenuCategory.Id == request.menuCategoryId && 
                   mi.MenuCategory.Menu.Id == request.menuId)
            .Select(mi => new MenuItemResponse(mi.Id, mi.Name, mi.Price))
            .ToListAsync();

        return Result.Success(new MenuItemsByCategoryResponse(menuItemList));
    }
}
