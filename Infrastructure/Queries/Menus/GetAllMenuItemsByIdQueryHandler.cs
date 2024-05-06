using Application.Menus.GetAllMenuItemsById;
using Application.Menus.GetByCategory;
using Domain.Menus;
using Domain.Shared;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries.Menus;

public class GetAllMenuItemsByIdQueryHandler(
    IMenuRepository repository) : IRequestHandler<GetAllMenuItemsByIdQuery, Result<AllMenuItemsResponse>>
{
    public async Task<Result<AllMenuItemsResponse>> Handle(
        GetAllMenuItemsByIdQuery request, 
        CancellationToken cancellationToken)
    {
        IEnumerable<MenuItem> menuItemsList = await repository
            .GetAllByIdAsync(request.menuId);

        return Result<AllMenuItemsResponse>.Success(
            new AllMenuItemsResponse(menuItemsList
                .Select(mi => new MenuItemResponse(mi.Id, mi.Name, mi.Price))));
    }
}
