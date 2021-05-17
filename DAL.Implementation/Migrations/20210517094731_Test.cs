using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Implementation.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "main" });

            migrationBuilder.InsertData(
                table: "DishMenus",
                columns: new[] { "Id", "DishId", "MenuId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "DishMenus",
                columns: new[] { "Id", "DishId", "MenuId" },
                values: new object[] { 2, 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DishMenus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DishMenus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
