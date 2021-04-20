using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Implementation.Migrations
{
    public partial class RestaurantDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooks_Specializations_SpecializationId",
                table: "Cooks");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Orders_OrderId",
                table: "DishOrders");

            migrationBuilder.DropIndex(
                name: "IX_Cooks_SpecializationId",
                table: "Cooks");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "CookingTime",
                table: "Orders",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "DishOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DishIngredient",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredient", x => new { x.DishesId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_DishIngredient_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredient_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredient_IngredientsId",
                table: "DishIngredient",
                column: "IngredientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Orders_OrderId",
                table: "DishOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Orders_OrderId",
                table: "DishOrders");

            migrationBuilder.DropTable(
                name: "DishIngredient");

            migrationBuilder.DropColumn(
                name: "CookingTime",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "DishOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_SpecializationId",
                table: "Cooks",
                column: "SpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooks_Specializations_SpecializationId",
                table: "Cooks",
                column: "SpecializationId",
                principalTable: "Specializations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Orders_OrderId",
                table: "DishOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
