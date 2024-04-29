using Domain.Shared;

namespace Domain.Menus;

public static class MenuErrors
{
    public static readonly Error InvalidMenuItems = Error.Validation("Menu.InvalidMenuItems", "Invalid menu items");
}
