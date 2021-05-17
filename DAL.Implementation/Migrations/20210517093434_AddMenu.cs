using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Implementation.Migrations
{
    public partial class AddMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishMenus_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishMenus_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Salad" },
                    { 2, "Meat" }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Salad" },
                    { 2, "Meat" }
                });

            migrationBuilder.InsertData(
                table: "Cooks",
                columns: new[] { "Id", "Efficiency", "Name", "SpecializationId", "Surname", "WhenIsFree" },
                values: new object[,]
                {
                    { 1, 0.0, "Jo", 1, "Cook", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2.0, "Cook", 2, "Cook", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "CookingTime", "Name", "Price", "SpecializationId", "Weight" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 20, 0, 0), "Salad", 100, 1, 3.0 },
                    { 2, new TimeSpan(0, 0, 20, 0, 0), "Meat", 100, 2, 3.0 }
                });

            migrationBuilder.InsertData(
                table: "DishIngredients",
                columns: new[] { "Id", "DishId", "IngredientId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "DishIngredients",
                columns: new[] { "Id", "DishId", "IngredientId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_SpecializationId",
                table: "Cooks",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_DishMenus_DishId",
                table: "DishMenus",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishMenus_MenuId",
                table: "DishMenus",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooks_Specializations_SpecializationId",
                table: "Cooks",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooks_Specializations_SpecializationId",
                table: "Cooks");

            migrationBuilder.DropTable(
                name: "DishMenus");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Cooks_SpecializationId",
                table: "Cooks");

            migrationBuilder.DeleteData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DishIngredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DishIngredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specializations",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
