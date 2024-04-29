using MediatR;

namespace Application.Orders.PlaceOrder;

public sealed record MenuItemCommand(
    Guid MenuItemId,
    string Name,
    decimal Price, 
    Guid MenuCategoryId);
