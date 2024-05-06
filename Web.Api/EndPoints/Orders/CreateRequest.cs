using Web.Api.EndPoints.Menus;

namespace Web.Api.EndPoints.Orders;

public sealed record CreateRequest(
    string? clientName, 
    IEnumerable<MenuItemRequest> menuItems);

public sealed record UpdateRequest(
    Guid id,
    string? clientName,
    IEnumerable<MenuItemRequest> menuItems);
