namespace Web.Api.EndPoints.Menus;

public sealed record MenuItemRequest(
    Guid id, 
    string name, 
    decimal cost,
    Guid menuCategoryId);
