using FluentValidation;
using Web.Api.EndPoints.Menus;

namespace Web.Api.EndPoints.Orders;

public class OrderRequestsValidator : AbstractValidator<PlaceOrderRequest>
{
    public OrderRequestsValidator()
    {
        RuleForEach(or => or.menuItems)
            .SetValidator(new MenuItemValidator());
    }
}

public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
{
    public UpdateOrderRequestValidator()
    {
        RuleForEach(or => or.menuItems)
            .SetValidator(new MenuItemValidator());
    }
}