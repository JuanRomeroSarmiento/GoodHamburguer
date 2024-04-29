using Domain.Menus;
using Domain.Orders.Discounts.DiscountByItems.Strategies;
using Domain.Shared;
using System.Reflection.Metadata;

namespace Domain.Orders.Discounts.DiscountByItems;

public static class DiscountByItemsIdentifier
{
    public static IDiscountByItems Identify(IEnumerable<MenuItem> menuItems)
    {
        if (ThreePack(menuItems))
            return new TwentyPercentDiscountByItems();
        if (TwoPackWithDrink(menuItems))
            return new FifteenPercentDiscountByItems();
        if (TwoPackWithFries(menuItems))
            return new TenPercentDiscountByItems();

        return new NonDiscountByItems();
    }

    private static bool ThreePack(IEnumerable<MenuItem> menuItems)
    {
        if (menuItems.Count() != 3)
            return false;
        if (!menuItems.Any(mi =>
            string.Equals(mi.Name, Constants.XBurger, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(mi.Name, Constants.XEgg, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(mi.Name, Constants.XBacon, StringComparison.OrdinalIgnoreCase)))
            return false;
        if (!menuItems.Any(mi => string.Equals(mi.Name,Constants.Fries, StringComparison.OrdinalIgnoreCase)))
            return false;
        if (!menuItems.Any(mi => string.Equals(mi.Name, Constants.SoftDrink, StringComparison.OrdinalIgnoreCase)))
            return false;

        return true;
    }
    private static bool TwoPackWithDrink(IEnumerable<MenuItem> menuItems)
    {
        if (menuItems.Count() != 2)
            return false;
        if (!menuItems.Any(mi => 
            string.Equals(mi.Name, Constants.XBurger, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(mi.Name, Constants.XEgg, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(mi.Name, Constants.XBacon, StringComparison.OrdinalIgnoreCase)))
            return false;
        if (!menuItems.Any(mi => string.Equals(mi.Name, Constants.SoftDrink, StringComparison.OrdinalIgnoreCase)))
            return false;

        return true;
    }
    private static bool TwoPackWithFries(IEnumerable<MenuItem> menuItems)
    {
        if (menuItems.Count() != 2)
            return false;
        if (!menuItems.Any(mi => 
            string.Equals(mi.Name, Constants.XBurger, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(mi.Name, Constants.XEgg, StringComparison.OrdinalIgnoreCase) ||
            string.Equals(mi.Name, Constants.XBacon, StringComparison.OrdinalIgnoreCase)))
            return false;
        if (!menuItems.Any(mi => string.Equals(mi.Name, Constants.Fries, StringComparison.OrdinalIgnoreCase)))
            return false;

        return true;
    }
}


