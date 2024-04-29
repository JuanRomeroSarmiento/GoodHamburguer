using Domain.Shared;
using MediatR;

namespace Application.Orders.GetAll;

public sealed record GetAllOrdersQuery() : IRequest<Result<OrdersResponse>>;
