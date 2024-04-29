using Application.Orders.PlaceOrder;
using Domain.Orders;
using Domain.Shared;
using MediatR;

namespace Application.Orders.Update;

public sealed record UpdateOrderCommand(
    Guid OrderId,
    string? ClientName,
    ICollection<MenuItemCommand> MenuItems) : IRequest<Result>;
