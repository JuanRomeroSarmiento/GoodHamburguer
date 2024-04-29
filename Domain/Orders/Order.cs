using Domain.Menus;
using Domain.Shared;
using System.Linq;

namespace Domain.Orders;

public class Order : Entity
{
    public string? ClientName { get; set; }
    public DateTime DateOfIssue { get; set; }
    public ICollection<OrderMenuItem> OrderMenuItems { get; set; }
    public decimal GrossPrice { get; set; }
    public decimal NetPrice { get; set; }

    public Order() { }
    private Order(
        Guid newOrderId,
        ICollection<OrderMenuItem> menuItems, 
        string? clientName)
    {
        Id = newOrderId;
        OrderMenuItems = menuItems;
        DateOfIssue = DateTime.Now;
        ClientName = clientName;
        GrossPrice = this.CalculateGrossPrice();
        NetPrice = GrossPrice;
    }

    private Order(
        Guid id,
        ICollection<OrderMenuItem> menuItems,
        DateTime dateOfIssue,
        string? clientName,
        decimal grossPrice,
        decimal netPrice)
    {
        Id = id;
        OrderMenuItems = menuItems;
        DateOfIssue = dateOfIssue;
        ClientName = clientName;
        GrossPrice = grossPrice;
        NetPrice = netPrice;
    }

    protected Order(Order order) : this(
        order.Id,
        order.OrderMenuItems,
        order.DateOfIssue,
        order.ClientName,
        order.GrossPrice,
        order.NetPrice)
    {}

    public static Result<Order> Create(
        Guid newOrderId,
        ICollection<OrderMenuItem> menuItems, 
        string? clientName)
    {
        if (menuItems.Count() == 0)
        {
            return Result.Failure<Order>(OrderErrors.Empty);
        }

        if (AreThereRepeatedItems(menuItems))
        {
            return Result.Failure<Order>(OrderErrors.RepeatedItems);
        }

        return new Order(newOrderId,menuItems, clientName);
    }
    public virtual decimal CalculateNetPrice() => NetPrice;

    public decimal CalculateGrossPrice() => 
        OrderMenuItems.Sum(omi => omi.MenuItem.Price);
    private static bool AreThereRepeatedItems(IEnumerable<OrderMenuItem> menuItems)
    {
        var duplicates = menuItems
            .GroupBy(omi => new { omi.MenuItemId })
            .Where(omi => omi.Skip(1).Any()).ToArray();

        return duplicates.Any() ? true : false;
    }
}


