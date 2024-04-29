using Application.Menus.GetAllMenuItemsById;
using Application.Menus.GetByCategory;
using Domain.Menus;
using Domain.Shared;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries.Menus;

public class GetAllMenuItemsByIdQueryHandler(
    ApplicationReadDbContext dbContext) : IRequestHandler<GetAllMenuItemsByIdQuery, Result<AllMenuItemsResponse>>
{
    public async Task<Result<AllMenuItemsResponse>> Handle(
        GetAllMenuItemsByIdQuery request, 
        CancellationToken cancellationToken)
    {
        IEnumerable<MenuItemResponse> menuItemsList = await dbContext.MenuItems
            .Where(mi => mi.MenuCategory.Menu.Id == request.menuId)
            .Select(mi => new MenuItemResponse(mi.Id, mi.Name, mi.Price))
            .ToListAsync();

        return Result<AllMenuItemsResponse>.Success(new AllMenuItemsResponse(menuItemsList));
    }
}
