using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Apex.Catering.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientRefId = table.Column<int>(type: "INTEGER", nullable: false),
                    NoOfguests = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodBookings_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuFoodItems",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "INTEGER", nullable: false),
                    FoodItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuFoodItems", x => new { x.MenuId, x.FoodItemId });
                    table.ForeignKey(
                        name: "FK_MenuFoodItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodItemMenuFoodItem",
                columns: table => new
                {
                    FoodItemsId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuFoodItemsMenuId = table.Column<int>(type: "INTEGER", nullable: false),
                    MenuFoodItemsFoodItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemMenuFoodItem", x => new { x.FoodItemsId, x.MenuFoodItemsMenuId, x.MenuFoodItemsFoodItemId });
                    table.ForeignKey(
                        name: "FK_FoodItemMenuFoodItem_FoodItems_FoodItemsId",
                        column: x => x.FoodItemsId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodItemMenuFoodItem_MenuFoodItems_MenuFoodItemsMenuId_MenuFoodItemsFoodItemId",
                        columns: x => new { x.MenuFoodItemsMenuId, x.MenuFoodItemsFoodItemId },
                        principalTable: "MenuFoodItems",
                        principalColumns: new[] { "MenuId", "FoodItemId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "A popular Indian dish made with marinated chicken cooked in a creamy tomato sauce.", "Chicken Tikka Masala", 12.99m },
                    { 2, "A Russian dish made with sautéed pieces of beef served in a sauce with sour cream.", "Beef Stroganoff", 14.99m },
                    { 3, "A quick and healthy dish made with a variety of fresh vegetables stir-fried in a savory sauce.", "Vegetable Stir Fry", 10.99m }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Indian Cuisine" },
                    { 2, "Russian Cuisine" },
                    { 3, "Vegetarian Cuisine" }
                });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodBookings_MenuId",
                table: "FoodBookings",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemMenuFoodItem_MenuFoodItemsMenuId_MenuFoodItemsFoodItemId",
                table: "FoodItemMenuFoodItem",
                columns: new[] { "MenuFoodItemsMenuId", "MenuFoodItemsFoodItemId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodBookings");

            migrationBuilder.DropTable(
                name: "FoodItemMenuFoodItem");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "MenuFoodItems");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
