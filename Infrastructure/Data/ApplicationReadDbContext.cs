using Domain.Menus;
using Domain.Orders;
using Infrastructure.Models.Read;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public sealed class ApplicationReadDbContext : DbContext
{
    public ApplicationReadDbContext(DbContextOptions<ApplicationReadDbContext> options) :
        base(options)
    {}

    public DbSet<MenuReadModel> Menus { get; set; }
    public DbSet<MenuCategoryReadModel> MenuCategories { get; set; }
    public DbSet<MenuItemReadModel> MenuItems { get; set; }
    public DbSet<OrderReadModel> Orders { get; set; }
    public DbSet<OrderMenuItemReadModel> OrderMenuItems { get; set; }

}
