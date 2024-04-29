using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClientName = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "TEXT", precision: 8, scale: 2, nullable: false),
                    NetPrice = table.Column<decimal>(type: "TEXT", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MenuId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuCategories_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 8, scale: 2, nullable: false),
                    MenuCategoryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuCategories_MenuCategoryId",
                        column: x => x.MenuCategoryId,
                        principalTable: "MenuCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderMenuItems",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MenuItemId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMenuItems", x => new { x.OrderId, x.MenuItemId });
                    table.ForeignKey(
                        name: "FK_OrderMenuItems_MenuItems_MenuItemId",
                        column: x => x.MenuItemId,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderMenuItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("44dec64b-a6a7-4083-80c1-962ae199169d"), "FastFood" });

            migrationBuilder.InsertData(
                table: "MenuCategories",
                columns: new[] { "Id", "MenuId", "Name" },
                values: new object[,]
                {
                    { new Guid("4ed27f3a-fa54-4e0b-a668-c541fbc50387"), new Guid("44dec64b-a6a7-4083-80c1-962ae199169d"), "Extras" },
                    { new Guid("9d201113-7724-45f8-8129-cf66c4fb3920"), new Guid("44dec64b-a6a7-4083-80c1-962ae199169d"), "Sandwich" }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "MenuCategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("76240b4e-cebe-41b9-bb48-87227de07207"), new Guid("9d201113-7724-45f8-8129-cf66c4fb3920"), "X Egg", 4.50m },
                    { new Guid("89e255d5-5184-49cf-b254-86968537d9d4"), new Guid("4ed27f3a-fa54-4e0b-a668-c541fbc50387"), "Fries", 2.00m },
                    { new Guid("c6cf893b-4af8-422c-ab76-1b02b43df73a"), new Guid("9d201113-7724-45f8-8129-cf66c4fb3920"), "X Burger", 5.00m },
                    { new Guid("e6c48b6a-f10f-4b20-beac-1067763e2a22"), new Guid("4ed27f3a-fa54-4e0b-a668-c541fbc50387"), "Soft drink", 2.50m },
                    { new Guid("f41adb1c-7ef9-467a-9ed5-2f855a63b412"), new Guid("9d201113-7724-45f8-8129-cf66c4fb3920"), "X Bacon", 7.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategories_MenuId",
                table: "MenuCategories",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuCategoryId",
                table: "MenuItems",
                column: "MenuCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMenuItems_MenuItemId",
                table: "OrderMenuItems",
                column: "MenuItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderMenuItems");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "MenuCategories");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
