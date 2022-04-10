using Microsoft.EntityFrameworkCore.Migrations;

namespace EnduroStore.Data.Migrations
{
    public partial class udateShoppingCartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingCarts");
        }
    }
}
