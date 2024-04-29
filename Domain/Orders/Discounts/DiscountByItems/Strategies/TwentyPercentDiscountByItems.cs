namespace Domain.Orders.Discounts.DiscountByItems.Strategies;

public class TwentyPercentDiscountByItems : IDiscountByItems
{
    public decimal CalculateNetPrice(decimal grossPrice) =>
        grossPrice - grossPrice * 0.2M;
}


