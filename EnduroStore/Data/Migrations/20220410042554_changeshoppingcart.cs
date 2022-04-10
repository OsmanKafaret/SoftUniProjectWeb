using Microsoft.EntityFrameworkCore.Migrations;

namespace EnduroStore.Data.Migrations
{
    public partial class changeshoppingcart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingCarts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ShoppingCarts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingCarts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
