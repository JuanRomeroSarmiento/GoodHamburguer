namespace Domain.Orders.Discounts.DiscountByItems.Strategies;

public class NonDiscountByItems : IDiscountByItems
{
    public decimal CalculateNetPrice(decimal grossPrice) => grossPrice;
}


