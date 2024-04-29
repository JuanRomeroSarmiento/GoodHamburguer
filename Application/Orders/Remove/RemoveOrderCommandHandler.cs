using Domain.Orders;
using Domain.Shared;
using MediatR;

namespace Application.Orders.Remove;

public class RemoveOrderCommandHandler(
    IOrderRepository repository) : IRequestHandler<DeleteOrderCommand, Result>
{
    public async Task<Result> Handle(
        DeleteOrderCommand command, 
        CancellationToken cancellationToken)
    {
        Order? order = await repository.GetByIdAsync(command.Id);
        if (order is null)
        {
            return Result.Failure(OrderErrors.NotFound(command.Id));
        }

        await repository.RemoveAsync(order);

        return Result.Success();
    }
}
