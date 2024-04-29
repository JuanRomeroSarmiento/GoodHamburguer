using Application.Menus.GetByCategory;
using Application.Orders.GetAll;
using Domain.Orders;
using Domain.Shared;
using Infrastructure.Data;
using Infrastructure.Models.Read;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries.Orders;

public class GetAllOrdersQueryHandler(
    ApplicationReadDbContext dbContext)
    : IRequestHandler<GetAllOrdersQuery, Result<OrdersResponse>>
{
    public async Task<Result<OrdersResponse>> Handle(
        GetAllOrdersQuery request, 
        CancellationToken cancellationToken)
    {
        IEnumerable<OrderResponse> orders = await dbContext.Orders
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
