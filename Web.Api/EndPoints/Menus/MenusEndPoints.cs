using Application.Menus.GetAllMenuItemsById;
using Application.Menus.GetByCategory;
using MediatR;
using System.Runtime.InteropServices;

namespace Web.Api.EndPoints.Menus;

public static class MenusEndPoints
{
    public static void MapMenuEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/menus");

        group.MapGet("{id}",GetAllMenuItemsByIdMenu);
        group.MapGet("{menuid}/category/{categoryid}", GetMenuItemsByCategoryId);
    }

    public static async Task<IResult> GetAllMenuItemsByIdMenu(
        Guid id,
        ISender sender)
    {
        var query = new GetAllMenuItemsByIdQuery(id);
        var menuItems = await sender.Send(query);
        return Results.Ok(menuItems);
    }

    public static async Task<IResult> GetMenuItemsByCategoryId(
        Guid menuid,
        Guid categoryid,
        ISender sender)
    {
        var query = new GetMenuItemsByCategoryIdQuery(menuid, categoryid);
        var menuItems = await sender.Send(query);
        return Results.Ok(menuItems);
    }
}
