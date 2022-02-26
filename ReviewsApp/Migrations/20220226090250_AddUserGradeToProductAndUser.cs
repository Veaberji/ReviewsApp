using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Migrations
{
    public partial class AddUserGradeToProductAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "UserGrades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserGrades",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrades_ProductId",
                table: "UserGrades",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGrades_UserId",
                table: "UserGrades",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrades_AspNetUsers_UserId",
                table: "UserGrades",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGrades_Products_ProductId",
                table: "UserGrades",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGrades_AspNetUsers_UserId",
                table: "UserGrades");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGrades_Products_ProductId",
                table: "UserGrades");

            migrationBuilder.DropIndex(
                name: "IX_UserGrades_ProductId",
                table: "UserGrades");

            migrationBuilder.DropIndex(
                name: "IX_UserGrades_UserId",
                table: "UserGrades");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "UserGrades");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserGrades");
        }
    }
}
