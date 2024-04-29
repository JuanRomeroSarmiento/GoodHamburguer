using Web.Api.EndPoints.Menus;

namespace Web.Api.EndPoints.Orders;

public sealed record OrderRequests(
    string? clientName, 
    IEnumerable<MenuItemRequest> menuItems);

public sealed record UpdateOrderRequest(
    Guid id,
    string? clientName,
    IEnumerable<MenuItemRequest> menuItems);
