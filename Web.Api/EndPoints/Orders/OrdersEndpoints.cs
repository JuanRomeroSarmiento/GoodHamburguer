using Application.Orders.GetAll;
using Application.Orders.PlaceOrder;
using Application.Orders.Remove;
using Application.Orders.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.EndPoints.Orders;

public static class OrdersEndpoints
{
    public static void MapOrderEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/orders");

        group.MapGet("", GetOrders);
        group.MapPost("", PlaceOrder);
        group.MapPut("", UpdateOrder);
        group.MapDelete("{id}", DeleteOrder);
    }

    public static async Task<IResult> GetOrders(ISender sender)
    {
        var query = new GetAllOrdersQuery();
        var orders = await sender.Send(query);
        return Results.Ok(orders);
    }

    public static async Task<IResult> PlaceOrder(
        OrderRequests request,
        ISender sender)
    {
        var command = new PlaceOrderCommand(
            request.clientName,
            request.menuItems
            .Select(mi => 
                new MenuItemCommand(
                    mi.id,
                    mi.name, 
                    mi.cost, 
                    mi.menuCategoryId)));

        var result = await sender.Send(command);

        return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Error);
    }

    public static async Task<IResult> UpdateOrder(
        UpdateOrderRequest request,
        ISender sender)
    {
        var command = new UpdateOrderCommand(
            request.id,
            request.clientName,
            request.menuItems
                .Select(mi =>
                    new MenuItemCommand(
                        mi.id,
                        mi.name,
                        mi.cost,
                        mi.menuCategoryId))
                .ToList());

        var result = await sender.Send(command);

        return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
    }

    public static async Task<IResult> DeleteOrder(
        Guid id,
        ISender sender)
    {
        var command = new DeleteOrderCommand(id);
        var result = await sender.Send(command);
        return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Error);
    }
}
