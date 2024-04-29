using Domain.Shared;
using MediatR;

namespace Application.Orders.PlaceOrder;

public sealed record PlaceOrderCommand(
    string? ClientName, 
    IEnumerable<MenuItemCommand> MenuItems) : IRequest<Result<PlacedOrderCostResponse>>;
