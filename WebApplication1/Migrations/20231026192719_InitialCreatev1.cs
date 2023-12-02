using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class InitialCreatev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ModelVuePizza_ModelVuePizzapizza_Id",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ModelVuePizzapizza_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "ModelVuePizzapizza_Id",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "type",
                table: "ModelVuePizza");

            migrationBuilder.DropColumn(
                name: "type",
                table: "ModelVueDrinks");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Drinks");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "ModelVuePizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "ModelVuePizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "ModelVueDrinks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Drinks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "name",
                table: "ModelVuePizza");

            migrationBuilder.DropColumn(
                name: "size",
                table: "ModelVuePizza");

            migrationBuilder.DropColumn(
                name: "name",
                table: "ModelVueDrinks");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Drinks");

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "Pizza",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModelVuePizzapizza_Id",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "ModelVuePizza",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "ModelVueDrinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "Drinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ModelVuePizzapizza_Id",
                table: "Orders",
                column: "ModelVuePizzapizza_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ModelVuePizza_ModelVuePizzapizza_Id",
                table: "Orders",
                column: "ModelVuePizzapizza_Id",
                principalTable: "ModelVuePizza",
                principalColumn: "pizza_Id");
        }
    }
}
