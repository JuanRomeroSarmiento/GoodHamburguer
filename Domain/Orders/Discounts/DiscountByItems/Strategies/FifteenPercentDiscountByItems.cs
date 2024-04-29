namespace Domain.Orders.Discounts.DiscountByItems.Strategies;

public class FifteenPercentDiscountByItems : IDiscountByItems
{
    public decimal CalculateNetPrice(decimal grossPrice) =>
        grossPrice - grossPrice * 0.15M;
}


