namespace Application.Menus.GetByCategory;

public sealed record MenuItemResponse(
    Guid Id,
    string Name,
    decimal Cost);
