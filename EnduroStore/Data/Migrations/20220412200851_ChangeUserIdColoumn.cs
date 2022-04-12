using Microsoft.EntityFrameworkCore.Migrations;

namespace EnduroStore.Data.Migrations
{
    public partial class ChangeUserIdColoumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrders_AspNetUsers_UserId1",
                table: "UserOrders");

            migrationBuilder.DropIndex(
                name: "IX_UserOrders_UserId1",
                table: "UserOrders");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserOrders");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserOrders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_UserId",
                table: "UserOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrders_AspNetUsers_UserId",
                table: "UserOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrders_AspNetUsers_UserId",
                table: "UserOrders");

            migrationBuilder.DropIndex(
                name: "IX_UserOrders_UserId",
                table: "UserOrders");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserOrders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_UserId1",
                table: "UserOrders",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrders_AspNetUsers_UserId1",
                table: "UserOrders",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
