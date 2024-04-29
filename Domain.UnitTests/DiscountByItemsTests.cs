using Domain.Menus;
using Domain.Orders.Discounts.DiscountByItems;
using Domain.Orders.Discounts.DiscountByItems.Strategies;
using FluentAssertions;

namespace Domain.UnitTests;

public class DiscountByItemsTests
{
    [Fact]
    public void Identify_Should_ReturnNonDiscount_When_NoApplicableDiscount()
    {
        // Arrange
        IEnumerable<MenuItem> menuItems = new List<MenuItem>();
        {
            new MenuItem(Guid.NewGuid(), "MenuItem1", 5.00M, Guid.NewGuid());
        }

        // Act 
        IDiscountByItems result = DiscountByItemsIdentifier.Identify(menuItems);

        // Assert
        result.GetType().Should().Be(typeof(NonDiscountByItems));
    }

    [Fact]
    public void Identify_Should_ReturnTwentyPercentDiscount_When_ApplicableDiscount()
    {
        // Arrange
        IEnumerable<MenuItem> menuItems = new List<MenuItem>()
        {
            new MenuItem(Guid.NewGuid(), "X Burger", 5.00M, Guid.NewGuid()),
            new MenuItem(Guid.NewGuid(), "Fries", 2.00M, Guid.NewGuid()),
            new MenuItem(Guid.NewGuid(), "Soft drink", 2.50M, Guid.NewGuid())
        };

        // Act 
        IDiscountByItems result = DiscountByItemsIdentifier.Identify(menuItems);

        // Assert
        result.GetType().Should().Be(typeof(TwentyPercentDiscountByItems));
    }

    [Fact]
    public void Identify_Should_ReturnFifteenPercent_When_ApplicableDiscount()
    {
        // Arrange
        IEnumerable<MenuItem> menuItems = new List<MenuItem>()
        {
            new MenuItem(Guid.NewGuid(), "X Burger", 5.00M, Guid.NewGuid()),
            new MenuItem(Guid.NewGuid(), "Soft drink", 5.00M, Guid.NewGuid())
        };

        // Act 
        IDiscountByItems result = DiscountByItemsIdentifier.Identify(menuItems);

        // Assert
        result.GetType().Should().Be(typeof(FifteenPercentDiscountByItems));
    }

    [Fact]
    public void Identify_Should_ReturnTenPercent_When_ApplicableDiscount()
    {
        // Arrange
        IEnumerable<MenuItem> menuItems = new List<MenuItem>()
        {
            new MenuItem(Guid.NewGuid(), "X Burger", 5.00M, Guid.NewGuid()),
            new MenuItem(Guid.NewGuid(), "Fries", 5.00M, Guid.NewGuid())
        };

        // Act 
        IDiscountByItems result = DiscountByItemsIdentifier.Identify(menuItems);

        // Assert
        result.GetType().Should().Be(typeof(TenPercentDiscountByItems));
    }
}
