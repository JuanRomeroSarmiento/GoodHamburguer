using Application.Menus.GetByCategory;
using Application.Orders.GetAll;
using Domain.Orders;
using Domain.Shared;
using Infrastructure.Data;
using Infrastructure.Models.Read;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace Infrastructure.Queries.Orders;

public class GetAllOrdersQueryHandler(
    ApplicationReadDbContext dbContext)
    : IRequestHandler<GetAllOrdersQuery, Result<OrdersResponse>>
{
    public async Task<Result<OrdersResponse>> Handle(
        GetAllOrdersQuery request, 
        CancellationToken cancellationToken)
    {
        var orderQuery = dbContext.Orders.AsQueryable();

        if (!string.IsNullOrEmpty(request.clientNameSearchTerm))
        {
            orderQuery = orderQuery
                .Where(o => o.ClientName.Contains(request.clientNameSearchTerm));
        }

        Expression<Func<OrderReadModel, object>> keySelector = request.sortColumn?.ToLower() switch
        {
            "clientname" => order => order.ClientName,
            "dateofissue" => order => order.DateOfIssue,
            _ => order => order.Id
        };

        orderQuery = request.sortOrder?.ToLower() == "desc" ?
                orderQuery.OrderByDescending(keySelector):
                orderQuery = orderQuery.OrderBy(keySelector);

        IEnumerable<OrderResponse> orders = await orderQuery
            .Skip((request.page - 1) * request.pageSize)
            .Take(request.pageSize)
            .Select(o => new OrderResponse(
                o.Id,
                o.ClientName,
                o.DateOfIssue,
                o.OrderMenuItems
                    .Select(mi => new MenuItemResponse(
                        mi.MenuItem.Id,
                        mi.MenuItem.Name,
                        mi.MenuItem.Price))
                    .ToList(),
                o.GrossPrice,
                o.NetPrice))
            .ToListAsync(cancellationToken);

        return new OrdersResponse(orders);
    }
}
