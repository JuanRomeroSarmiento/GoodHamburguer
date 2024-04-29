using Domain.Menus;

namespace Infrastructure.Models.Read;

public class OrderReadModel
{
    public Guid Id { get; set; }
    public string? ClientName { get; set; }
    public DateTime DateOfIssue { get; set; }
    public decimal GrossPrice { get; set; }
    public decimal NetPrice { get; set; }
    public IEnumerable<OrderMenuItemReadModel> OrderMenuItems { get; set; } = Enumerable.Empty<OrderMenuItemReadModel>();

}
