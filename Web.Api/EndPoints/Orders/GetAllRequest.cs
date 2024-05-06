using Microsoft.AspNetCore.Mvc;

namespace Web.Api.EndPoints.Orders;

public sealed record GetAllRequest(
    string? ClientNameSearchTerm,
    string? SortColumn,
    string? SortOrder,
    int Page,
    int PageSize);
