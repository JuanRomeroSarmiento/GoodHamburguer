using Domain.Shared;

namespace Domain.Orders;

public static class OrderErrors
{
    public static readonly Error Empty = Error.Validation("Order.MenuItems","Order without menu items.");
    public static readonly Error RepeatedItems = Error.Validation("Order.RepeatedItems","Order with items repeated.");
    public static readonly Error SortColumnEmpty = Error.Validation("Order.GetAll", "SortColumn empty. Invalid value.");
    public static readonly Error SortColumnNoValid = 
        Error.Validation("Order.GetAll", "SortColumn with invalid value. Only 'clientname' and 'dateofissue' are allowed.");
    public static readonly Error SortOrderEmpty = Error.Validation("Order.GetAll", "SortOrder empty. Invalid value.");
    public static readonly Error SortOrderNoValid = 
        Error.Validation("Order.GetAll", "SortOrder with invalid value. Only 'asc' and 'desc' are allowed.");
    public static readonly Error PageNoValid = Error.Validation("Order.GetAll", "Page with invalid value");
    public static readonly Error PageSizeNoValid = Error.Validation("Order.GetAll", "PageSize with invalid value.");
    public static Error NotFound(Guid id) => Error.NotFound(
        "Order.NotFound", $"The order with the Id = '{id}' was not found");
}
