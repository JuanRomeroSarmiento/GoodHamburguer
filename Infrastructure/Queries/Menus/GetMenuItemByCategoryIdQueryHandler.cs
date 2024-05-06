using Application.Menus.GetByCategory;
using Domain.Menus;
using Domain.Shared;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries.Menus;

public class GetMenuItemByCategoryIdQueryHandler(
    IMenuRepository repository) 
    : IRequestHandler<GetMenuItemsByCategoryIdQuery, Result<MenuItemsByCategoryResponse>>
{
    public async Task<Result<MenuItemsByCategoryResponse>> Handle(
        GetMenuItemsByCategoryIdQuery request, 
        CancellationToken cancellationToken)
    {
        IEnumerable<MenuItem> menuItemList = await repository
            .GetByCategoryIdAsync(request.menuCategoryId);

        return Result.Success(
            new MenuItemsByCategoryResponse(
                menuItemList
                .Select(mi => new MenuItemResponse(mi.Id, mi.Name, mi.Price))));
    }
}
