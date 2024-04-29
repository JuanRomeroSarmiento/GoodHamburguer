using Application.Menus.GetByCategory;

namespace Application.Menus.GetAllMenuItemsById;

public sealed record AllMenuItemsResponse(
    IEnumerable<MenuItemResponse> MenuItemResponses);
