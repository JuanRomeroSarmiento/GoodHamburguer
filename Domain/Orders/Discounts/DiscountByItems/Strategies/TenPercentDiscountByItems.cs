namespace Domain.Orders.Discounts.DiscountByItems.Strategies;

public class TenPercentDiscountByItems : IDiscountByItems
{
    public decimal CalculateNetPrice(decimal grossPrice) =>
        grossPrice - grossPrice * 0.1M;
}


