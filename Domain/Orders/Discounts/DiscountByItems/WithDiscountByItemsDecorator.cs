using Domain.Orders.Discounts.DiscountByItems.Strategies;

namespace Domain.Orders.Discounts.DiscountByItems;

public class WithDiscountByItemsDecorator : Order
{
    public WithDiscountByItemsDecorator(Order other) : base(other) { }

    public override decimal CalculateNetPrice()
    {
        var menuItems = this.OrderMenuItems.Select(omi => omi.MenuItem);
        IDiscountByItems discountToBeApplied = DiscountByItemsIdentifier.Identify(menuItems);
        NetPrice = discountToBeApplied.CalculateNetPrice(GrossPrice);
        return NetPrice;
    }
}


