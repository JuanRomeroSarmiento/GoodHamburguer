using Domain.Shared;

namespace Domain.Menus;

public static class MenuErrors
{
    public static readonly Error InvalidMenuItems = Error.Validation("Menu.InvalidMenuItems", "Invalid menu items");

    public static readonly Error MenuItemWithoutId = 
        Error.Validation("MenuItem.WithoutId", "Menu Item without Id");
    public static readonly Error MenuItemWithoutName = 
        Error.Validation("MenuItem.WithoutName", "Menu Item without Name");
    public static readonly Error MenuItemWithoutCost = 
        Error.Validation("MenuItem.WithoutCost", "Menu Item without Cost");
    public static readonly Error MenuItemWithCostNotGreaterThanZero = 
        Error.Validation("MenuItem.WithoutCostNotGreaterThanZero", "Menu Item with cost not greater than zero");
    public static readonly Error MenuItemWithoutCategoryId = 
        Error.Validation("MenuItem.WithoutCategoryId", "Menu Item without CategoryId");
}
