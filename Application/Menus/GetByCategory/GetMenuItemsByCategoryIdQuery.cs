using Domain.Shared;
using MediatR;

namespace Application.Menus.GetByCategory;

public sealed record GetMenuItemsByCategoryIdQuery(
    Guid menuId,
    Guid menuCategoryId) : IRequest<Result<MenuItemsByCategoryResponse>>;
