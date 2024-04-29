using Application.Menus.GetByCategory;

namespace Application.Orders.GetAll;

public record OrderResponse(
    Guid Id, 
    string? ClientName,
    DateTime DateOfIssue,
    IEnumerable<MenuItemResponse>  MenuItemResponses,
    decimal GrossPrice,
    decimal NetPrice);
