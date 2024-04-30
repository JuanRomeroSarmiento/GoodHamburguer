using Domain.Orders;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class OrderRepository(ApplicationWriteDbContext dbContext) : IOrderRepository
{
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await dbContext.Orders.ToListAsync();
    }

    public async Task<Order> GetByIdAsync(Guid id)
    {
        return await dbContext.Orders.FirstAsync(o => o.Id == id);
    }

    public async Task PlaceOrderAsync(Order order)
    {
        var orderToInsert = new Order()
        {
            Id = order.Id,
            ClientName = order.ClientName,
            DateOfIssue = order.DateOfIssue,
            GrossPrice = order.GrossPrice,
            NetPrice = order.NetPrice,
            OrderMenuItems = order.OrderMenuItems
            .Select(omi => new OrderMenuItem() { OrderId = omi.OrderId, MenuItemId = omi.MenuItemId })
            .ToList()
        };

        dbContext.Orders.Add(orderToInsert);

        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(Order order)
    {
        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        var oldMenuItems = await dbContext.OrderMenuItems
            .Where(omi => omi.OrderId == order.Id)
            .ToListAsync();

        dbContext.OrderMenuItems.RemoveRange(oldMenuItems);

        dbContext.Update(order);

        await dbContext.SaveChangesAsync();
    }
}
