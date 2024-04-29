namespace Application.Orders.GetAll;

public record OrdersResponse(IEnumerable<OrderResponse> Orders);