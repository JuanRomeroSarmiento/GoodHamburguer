using Domain.Menus;
using FluentValidation;

namespace Web.Api.EndPoints.Menus;

public class MenuItemValidator : AbstractValidator<MenuItemRequest>
{
    public MenuItemValidator()
    {
        RuleFor(mi => mi.id)
            .NotEmpty().WithMessage(MenuErrors.MenuItemWithoutId.Description);
        RuleFor(mi => mi.name)
            .NotEmpty().WithMessage(MenuErrors.MenuItemWithoutName.Description);
        RuleFor(mi => mi.cost)
            .NotEmpty().WithMessage(MenuErrors.MenuItemWithoutCost.Description)
            .GreaterThan(0).WithMessage(MenuErrors.MenuItemWithCostNotGreaterThanZero.Description);
        RuleFor(mi => mi.menuCategoryId)
            .NotEmpty().WithMessage(MenuErrors.MenuItemWithoutCategoryId.Description);
    }
}
