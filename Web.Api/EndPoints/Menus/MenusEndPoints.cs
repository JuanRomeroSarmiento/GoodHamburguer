using Application.Menus.GetAllMenuItemsById;
using Application.Menus.GetByCategory;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Runtime.InteropServices;

namespace Web.Api.EndPoints.Menus;

public static class MenusEndPoints
{
    public static void MapMenuEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/menus")
            .WithTags("Menus");

        group.MapGet("{id}/menuitems/",GetAll)
            .WithName("GetAllMenuItemsByMenuId")
            .WithOpenApi(op => new(op)
            {
                Description = "Operation to get all menu items by menu id"
            });

        group.MapGet("{menuid}/category/{categoryid}/menuitems/", GetByCategory)
            .WithName("GetMenuItemsByCategoryId")
            .WithOpenApi(op => new(op)
            {
                Description = "Operation to get all menu items associated with a specific menu id filtered by category id"
            });
    }

    public static async Task<Ok<AllMenuItemsResponse>> GetAll(
        Guid id,
        ISender sender)
    {
        var query = new GetAllMenuItemsByIdQuery(id);
        var menuItems = await sender.Send(query);
        return TypedResults.Ok(menuItems.Value);
    }

    public static async Task<Ok<MenuItemsByCategoryResponse>> GetByCategory(
        Guid menuid,
        Guid categoryid,
        ISender sender)
    {
        var query = new GetMenuItemsByCategoryIdQuery(menuid, categoryid);
        var menuItems = await sender.Send(query);
        return TypedResults.Ok(menuItems.Value);
    }
}
