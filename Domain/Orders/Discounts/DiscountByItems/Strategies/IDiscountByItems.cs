namespace Domain.Orders.Discounts.DiscountByItems.Strategies;

public interface IDiscountByItems
{
    decimal CalculateNetPrice(decimal grossPrice);
}


