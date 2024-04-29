using Domain.Shared;

namespace Domain.Orders;

public static class OrderErrors
{
    public static readonly Error Empty = Error.Validation("Order.MenuItems","Order without menu items");
    public static readonly Error RepeatedItems = Error.Validation("Order.RepeatedItems","Order with items repeated.");

    public static Error NotFound(Guid id) => Error.NotFound(
        "Order.NotFound", $"The order with the Id = '{id}' was not found");
}
