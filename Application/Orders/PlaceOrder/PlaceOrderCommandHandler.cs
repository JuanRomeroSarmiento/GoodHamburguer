using Domain.Menus;
using Domain.Orders;
using Domain.Orders.Discounts.DiscountByItems;
using Domain.Shared;
using MediatR;

namespace Application.Orders.PlaceOrder;

public class PlaceOrderCommandHandler(
    IOrderRepository orderRepository)
    : IRequestHandler<PlaceOrderCommand, Result<PlacedOrderCostResponse>>
{
    public async Task<Result<PlacedOrderCostResponse>> Handle(
        PlaceOrderCommand request, 
        CancellationToken cancellationToken)
    {
        var newOrderId = Guid.NewGuid();
        Result<Order> newOrderResult = Order.Create(
            newOrderId,
            request.MenuItems
            .Select(mi => new OrderMenuItem()
            {
                 OrderId = newOrderId,
                 MenuItemId = mi.MenuItemId,
                 MenuItem = new MenuItem(mi.MenuItemId, mi.Name, mi.Price, mi.MenuCategoryId)
            })
            .ToList(),
            request.ClientName);

        if (newOrderResult.IsFailure)
        {
            return Result.Failure<PlacedOrderCostResponse>(newOrderResult.Error);
        }

        Order newOrder = newOrderResult.Value;

        Order withDiscountByItems = new WithDiscountByItemsDecorator(newOrder);
        var netPrice = withDiscountByItems.CalculateNetPrice();
        await orderRepository.PlaceOrderAsync(withDiscountByItems);

        return Result.Success(
            new PlacedOrderCostResponse(netPrice));
    }
}
