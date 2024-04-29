namespace Application.Menus.GetByCategory;

public sealed record MenuItemsByCategoryResponse(IEnumerable<MenuItemResponse> MenuItemResponses);
