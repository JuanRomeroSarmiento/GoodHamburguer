using Domain.Menus;
using Domain.Orders;
using Domain.Shared;
using FluentAssertions;

namespace Domain.UnitTests;

public class OrderTests
{

    [Fact]
    public void Create_Should_ReturnError_When_NoMenuItems()
    {
        // Arrange
        ICollection<OrderMenuItem> orderMenuItems = Enumerable.Empty<OrderMenuItem>().ToList();
        Guid newOrderId = Guid.NewGuid();

        // Act
        Result<Order> result = Order.Create(newOrderId, orderMenuItems, "UserTest");

        //Assert
        result.Error.Should().Be(OrderErrors.Empty);
    }

    [Fact]
    public void Create_Should_ReturnError_When_ItemsRepeated()
    {
        // Arrange
        Guid newOrderId = Guid.NewGuid();
        Guid menuItemIdRepeated = Guid.NewGuid();
        ICollection<OrderMenuItem> orderMenuItems = new List<OrderMenuItem>() 
        { 
            new OrderMenuItem(){ OrderId = newOrderId, MenuItemId = menuItemIdRepeated },
            new OrderMenuItem(){ OrderId = newOrderId, MenuItemId = menuItemIdRepeated }
        };
        
        // Act
        Result<Order> result = Order.Create(newOrderId, orderMenuItems, "UserTest");

        //Assert
        result.Error.Should().Be(OrderErrors.RepeatedItems);
    }

    [Fact]
    public void Create_Should_ReturnNewOrder_WhenCreateSucceeds()
    {
        // Arrange
        Guid newOrderId = Guid.NewGuid();
        Guid menuItemId = Guid.NewGuid();
        Guid categoryId = Guid.NewGuid();
        string clientName = "UserTest";
        ICollection<OrderMenuItem> orderMenuItems = new List<OrderMenuItem>()
        {
            new OrderMenuItem(){ 
                OrderId = newOrderId, 
                MenuItemId = menuItemId,
                MenuItem = new MenuItem(menuItemId, "MenuItem1", 5.00M, categoryId)},
        };

        // Act
        Result<Order> result = Order.Create(newOrderId, orderMenuItems, clientName);

        //Assert
        result.Value.Id.Should().Be(newOrderId);
        result.Value.ClientName.Should().Be(clientName);
        result.Value.GrossPrice.Should().Be(5.00M);
        result.Value.NetPrice.Should().Be(5.00M);
        result.Value.OrderMenuItems.Count().Should().Be(1);
        result.Value.OrderMenuItems.Select(omi => omi.MenuItemId).First().Should().Be(menuItemId);
    }

    [Fact]
    public void CalculateGrossPrice_Should_ReturnSumPrice_WhenCalculate()
    {
        // Arrange
        Guid newOrderId = Guid.NewGuid();
        Guid menuItemId1 = Guid.NewGuid();
        Guid menuItemId2 = Guid.NewGuid();
        Guid categoryId = Guid.NewGuid();
        string clientName = "UserTest";
        ICollection<OrderMenuItem> orderMenuItems = new List<OrderMenuItem>()
        {
            new OrderMenuItem(){
                OrderId = newOrderId,
                MenuItemId = menuItemId1,
                MenuItem = new MenuItem(menuItemId1, "MenuItem1", 5.00M, categoryId)},
            new OrderMenuItem(){
                OrderId = newOrderId,
                MenuItemId = menuItemId2,
                MenuItem = new MenuItem(menuItemId2, "MenuItem2", 5.00M, categoryId)},
        };

        // Act
        Result<Order> result = Order.Create(newOrderId, orderMenuItems, clientName);

        //Assert
        result.Value.Id.Should().Be(newOrderId);
        result.Value.ClientName.Should().Be(clientName);
        result.Value.GrossPrice.Should().Be(10.00M);
        result.Value.NetPrice.Should().Be(10.00M);
        result.Value.OrderMenuItems.Count().Should().Be(2);
        result.Value.OrderMenuItems.Select(omi => omi.MenuItemId).Take(1).First().Should().Be(menuItemId1);
        result.Value.OrderMenuItems.Select(omi => omi.MenuItemId).Skip(1).First().Should().Be(menuItemId2);
    }
}
