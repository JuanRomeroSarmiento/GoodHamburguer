using Domain.Menus;
using Domain.Orders;
using Domain.Orders.Discounts.DiscountByItems;
using Domain.Shared;
using MediatR;

namespace Application.Orders.Update;

public class UpdateOrderCommandHandler(
    IOrderRepository orderRepository) : IRequestHandler<UpdateOrderCommand, Result>
{
    public async Task<Result> Handle(
        UpdateOrderCommand command, 
        CancellationToken cancellationToken)
    {
        if(command.MenuItems is null || command.MenuItems.Count() == 0)
        {
            return Result.Failure(OrderErrors.Empty);
        }

        Order order = await orderRepository.GetByIdAsync(command.OrderId);
        if (order is null) 
        {
            return Result.Failure(OrderErrors.NotFound(command.OrderId));
        }

        order.ClientName = command.ClientName;
        //order.OrderMenuItems = command.MenuItems
        //        .Select(mi => 
        //            new OrderMenuItem() 
        //            {
        //                OrderId = order.Id,
        //                MenuItemId = mi.MenuItemId,
        //                MenuItem = new MenuItem(mi.MenuItemId, mi.Name, mi.Price, mi.MenuCategoryId)
        //            })
        //        .ToList();

        //order.GrossPrice = order.CalculateGrossPrice();
        //Order withDiscountByItems = new WithDiscountByItemsDecorator(order);
        //order.NetPrice = withDiscountByItems.CalculateNetPrice();

        await orderRepository.UpdateAsync(order);

        return Result.Success();
    }
}
