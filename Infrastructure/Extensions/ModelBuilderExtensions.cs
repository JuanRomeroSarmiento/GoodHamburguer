using Domain.Menus;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    private static readonly Guid MenuId = new("44DEC64B-A6A7-4083-80C1-962AE199169D");
    private static readonly Guid SandwichCategoryId = new("9D201113-7724-45F8-8129-CF66C4FB3920");
    private static readonly Guid ExtrasCategoryId = new("4ED27F3A-FA54-4E0B-A668-C541FBC50387");
    private static readonly Guid XBurgerItemId = new("C6CF893B-4AF8-422C-AB76-1B02B43DF73A");
    private static readonly Guid XEggItemId = new("76240B4E-CEBE-41B9-BB48-87227DE07207");
    private static readonly Guid XBaconItemId = new("F41ADB1C-7EF9-467A-9ED5-2F855A63B412");
    private static readonly Guid FriesItemId = new("89E255D5-5184-49CF-B254-86968537D9D4");
    private static readonly Guid SoftDrinkItemId = new("E6C48B6A-F10F-4B20-BEAC-1067763E2A22");
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Menu>().HasData(new Menu { Id = MenuId, Name = Constants.FastFood });

        modelBuilder.Entity<MenuCategory>().HasData(
            new MenuCategory { Id = SandwichCategoryId, Name = Constants.Sandwich , MenuId = MenuId});
        modelBuilder.Entity<MenuCategory>().HasData(
            new MenuCategory { Id = ExtrasCategoryId, Name = Constants.Extras , MenuId = MenuId});

        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem(XBurgerItemId,Constants.XBurger, 5.00M,SandwichCategoryId));
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem(XEggItemId, Constants.XEgg, 4.50M, SandwichCategoryId));
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem(XBaconItemId,Constants.XBacon, 7.00M, SandwichCategoryId));

        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem(FriesItemId, Constants.Fries, 2.00M, ExtrasCategoryId)); 
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem(SoftDrinkItemId, Constants.SoftDrink, 2.50M, ExtrasCategoryId));
    }
}
