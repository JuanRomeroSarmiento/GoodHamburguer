using Domain.Shared;
using MediatR;

namespace Application.Orders.Remove;

public sealed record DeleteOrderCommand(Guid Id) : IRequest<Result>;
