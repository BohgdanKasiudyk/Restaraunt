using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Implementation.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishMenus_Menus_MenuId",
                table: "DishMenus");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "DishMenus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "DishMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuId",
                value: null);

            migrationBuilder.UpdateData(
                table: "DishMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_DishMenus_Menus_MenuId",
                table: "DishMenus",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishMenus_Menus_MenuId",
                table: "DishMenus");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "DishMenus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DishMenus",
                keyColumn: "Id",
                keyValue: 1,
                column: "MenuId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DishMenus",
                keyColumn: "Id",
                keyValue: 2,
                column: "MenuId",
                value: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_DishMenus_Menus_MenuId",
                table: "DishMenus",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
