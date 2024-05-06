using Application.Orders.GetAll;
using Application.Orders.PlaceOrder;
using Application.Orders.Remove;
using Application.Orders.Update;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Filters;

namespace Web.Api.EndPoints.Orders;

public static class OrdersEndpoints
{
    public static void MapOrderEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/orders")
            .WithTags("Orders");

        group.MapGet("", GetAll)
            .AddEndpointFilter<ValidationFilter<GetAllRequest>>()
            .WithName("GetAllOrders")
            .WithOpenApi(generatedOperation =>
            {
                generatedOperation.Parameters[0].Description = "Only client Name can be used for filtering ";
                generatedOperation.Parameters[1].Description = "Only 'clientName' and 'DateOfIssue' values allowed";
                generatedOperation.Parameters[2].Description = "Only 'asc' and 'desc' values allowed";
                return generatedOperation;
            })
            .WithOpenApi(op => new(op)
            {
                Description = "Operation to get all orders registered in the system in a paginated manner " +
                              "with the option to filter by name of client sorted ascending and descending"
            });

        group.MapPost("", Create)
            .AddEndpointFilter<ValidationFilter<CreateRequest>>()
            .WithName("CreateOrder")
            .WithOpenApi(op => new(op)
            {
                Description = "Operation to create a new order in the system." +
                              "Orders without items or with repeated items are not allowed."
            });

        group.MapPut("", Update)
            .AddEndpointFilter<ValidationFilter<UpdateRequest>>()
            .WithName("UpdateOrder")
            .WithOpenApi(op => new(op)
            {
                Description = "Operation to update an existing order in the system." +
                              "Updates without items or with repeated items are not allowed."
            });

        group.MapDelete("{id}", Delete)
            .WithName("DeleteOrder")
            .WithOpenApi(op => new(op)
            {
                Description = "Operation to delete an existing order in the system."
            });
    }

    public static async Task<Ok<OrdersResponse>> GetAll(
        [AsParameters] GetAllRequest request,
        ISender sender)
    {
        var query = new GetAllOrdersQuery(
            request.ClientNameSearchTerm, 
            request.SortColumn, 
            request.SortOrder, 
            request.Page, 
            request.PageSize);

        var orders = await sender.Send(query);
        return TypedResults.Ok(orders.Value);
    }

    public static async Task<Results<Ok<PlacedOrderCostResponse>, BadRequest<Error>>> Create(
        CreateRequest request,
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

        return result.IsSuccess ? 
            TypedResults.Ok(result.Value) :
            TypedResults.BadRequest(result.Error);
    }

    public static async Task<Results<Ok, BadRequest<Error>>> Update(
        UpdateRequest request,
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

        return result.IsSuccess ? 
            TypedResults.Ok() : 
            TypedResults.BadRequest(result.Error);
    }

    public static async Task<Results<Ok, BadRequest<Error>>> Delete(
        Guid id,
        ISender sender)
    {
        var command = new DeleteOrderCommand(id);
        var result = await sender.Send(command);
        return result.IsSuccess ? 
            TypedResults.Ok() : 
            TypedResults.BadRequest(result.Error);
    }
}
