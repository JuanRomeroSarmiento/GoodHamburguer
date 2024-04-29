namespace Domain.Orders;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order> GetByIdAsync(Guid id);
    Task PlaceOrderAsync(Order order);
    Task UpdateAsync(Order order);
    Task RemoveAsync(Order order);
}
