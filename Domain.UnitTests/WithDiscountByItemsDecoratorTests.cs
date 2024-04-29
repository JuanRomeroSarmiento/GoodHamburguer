using Domain.Menus;
using Domain.Orders;
using Domain.Orders.Discounts.DiscountByItems;
using Domain.Shared;
using FluentAssertions;

namespace Domain.UnitTests;

public class WithDiscountByItemsDecoratorTests
{
    [Fact]
    public void CalculateNetPrice_Should_ReturnNetPriceWithTwentyPercentDiscounted()
    {
        // Arrange
        Guid newOrderId = Guid.NewGuid();
        Guid menuCategoryId = Guid.NewGuid();   
        Guid menuItemId1 = Guid.NewGuid();
        Guid menuItemId2 = Guid.NewGuid();
        Guid menuItemId3 = Guid.NewGuid();

        ICollection<OrderMenuItem> menuItems = new List<OrderMenuItem>()
        {
            new OrderMenuItem(){
                OrderId = newOrderId,
                MenuItemId = menuItemId1,
                MenuItem = new MenuItem(menuItemId1, "X Burger", 5.00M, menuCategoryId)},
            new OrderMenuItem(){
                OrderId = newOrderId,
                MenuItemId = menuItemId2,
                MenuItem = new MenuItem(menuItemId2, "Fries", 2.00M, menuCategoryId)},
            new OrderMenuItem(){
                OrderId = newOrderId,
                MenuItemId = menuItemId3,
                MenuItem = new MenuItem(menuItemId3, "Soft drink", 2.50M, menuCategoryId)},
        };
        Result<Order> newOrderResult = Order.Create(newOrderId, menuItems,"testUser");
        WithDiscountByItemsDecorator decorator = new WithDiscountByItemsDecorator(newOrderResult.Value);

        // Act
        var result = decorator.CalculateNetPrice();

        // Assert
        result.GetType().Should().Be(typeof(decimal));
        result.Should().Be(7.6M);
    }

    [Fact]
    public void CalculateNetPrice_Should_ReturnNetPriceWithFifteenPercentDiscounted()
    {
        // Arrange
        Guid newOrderId = Guid.NewGuid();
        Guid menuCategoryId = Guid.NewGuid();
        Guid menuItemId1 = Guid.NewGuid();
        Guid menuItemId2 = Guid.NewGuid();

        ICollection<OrderMenuItem> menuItems = new List<OrderMenuItem>()
        {
            new OrderMenuItem(){
                OrderId = newOrderId,
                MenuItemId = menuItemId1,
                MenuItem = new MenuItem(menuItemId1, "X Burger", 5.00M, menuCategoryId)},            
            new OrderMenuItem(){
                OrderId = newOrderId,
                MenuItemId = menuItemId2,
                MenuItem = new MenuItem(menuItemId2, "Soft drink", 2.50M, menuCategoryId)},
        };
        Result<Order> newOrderResult = Order.Create(newOrderId, menuItems, "testUser");
        WithDiscountByItemsDecorator decorator = new WithDiscountByItemsDecorator(newOrderResult.Value);

        // Act
        var result = decorator.CalculateNetPrice();

        // Assert
        result.GetType().Should().Be(typeof(decimal));
        result.Should().Be(6.3750M);
    }

    [Fact]
    public void CalculateNetPrice_Should_ReturnNetPriceWithTenPercentDiscounted()
    {
        // Arrange
        Guid newOrderId = Guid.NewGuid();
        Guid menuCategoryId = Guid.NewGuid();
        Guid menuItemId1 = Guid.NewGuid();
        Guid menuItemId2 = Guid.NewGuid();

        ICollection<OrderMenuItem> menuItems = new List<OrderMenuItem>()
        {
            new OrderMenuItem(){
                OrderId = newOrderId,
                MenuItemId = menuItemId1,
                MenuItem = new MenuItem(menuItemId1, "X Burger", 5.00M, menuCategoryId)},
            new OrderMenuItem(){
                OrderId = newOrderId,
                MenuItemId = menuItemId2,
                MenuItem = new MenuItem(menuItemId2, "Fries", 2.00M, menuCategoryId)},
        };
        Result<Order> newOrderResult = Order.Create(newOrderId, menuItems, "testUser");
        WithDiscountByItemsDecorator decorator = new WithDiscountByItemsDecorator(newOrderResult.Value);

        // Act
        var result = decorator.CalculateNetPrice();

        // Assert
        result.GetType().Should().Be(typeof(decimal));
        result.Should().Be(6.3M);
    }
}
