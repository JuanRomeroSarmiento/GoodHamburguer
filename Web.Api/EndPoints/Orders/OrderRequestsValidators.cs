using Domain.Orders;
using FluentValidation;
using Web.Api.EndPoints.Menus;

namespace Web.Api.EndPoints.Orders;

public class GetAllRequestsValidator: AbstractValidator<GetAllRequest>
{
    public GetAllRequestsValidator()
    {
        When(r => r.SortColumn is not null, () =>
        {
            RuleFor(r => r.SortColumn)
                .NotEmpty().WithMessage(OrderErrors.SortColumnEmpty.Description)
                .Must(r => r!.Equals("clientname", StringComparison.OrdinalIgnoreCase) ||
                           r.Equals("dateofissue", StringComparison.OrdinalIgnoreCase))
                .WithMessage(OrderErrors.SortColumnNoValid.Description);
        });

        When(r => r.SortOrder is not null, () =>
        {
            RuleFor(r => r.SortOrder)
                .NotEmpty().WithMessage(OrderErrors.SortOrderEmpty.Description)
                .Must(r => r!.Equals("asc", StringComparison.OrdinalIgnoreCase) ||
                           r.Equals("desc", StringComparison.OrdinalIgnoreCase))
                .WithMessage(OrderErrors.SortOrderNoValid.Description);
        });

        RuleFor(r => r.Page)
            .GreaterThan(0).WithMessage(OrderErrors.PageNoValid.Description);
        RuleFor(r => r.PageSize)
            .GreaterThan(0).WithMessage(OrderErrors.PageSizeNoValid.Description);
    }
}

public class OrderRequestsValidator : AbstractValidator<CreateRequest>
{
    public OrderRequestsValidator()
    {
        RuleForEach(or => or.menuItems)
            .SetValidator(new MenuItemValidator());
    }
}

public class UpdateOrderRequestValidator : AbstractValidator<UpdateRequest>
{
    public UpdateOrderRequestValidator()
    {
        RuleForEach(or => or.menuItems)
            .SetValidator(new MenuItemValidator());
    }
}