using Domain.Shared;
using MediatR;

namespace Application.Menus.GetAllMenuItemsById;

public sealed record GetAllMenuItemsByIdQuery(Guid menuId) : IRequest<Result<AllMenuItemsResponse>>;
