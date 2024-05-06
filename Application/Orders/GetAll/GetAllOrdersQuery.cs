using Domain.Shared;
using MediatR;

namespace Application.Orders.GetAll;

public sealed record GetAllOrdersQuery(
    string? clientNameSearchTerm,
    string? sortColumn,
    string? sortOrder,
    int page,
    int pageSize) : IRequest<Result<OrdersResponse>>;
