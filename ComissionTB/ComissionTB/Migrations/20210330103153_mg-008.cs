using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionTB.Migrations
{
    public partial class mg008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cex_AspNetUsers_UserIdId",
                table: "cex");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "cex",
                newName: "appUserId");

            migrationBuilder.RenameIndex(
                name: "IX_cex_UserIdId",
                table: "cex",
                newName: "IX_cex_appUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_cex_AspNetUsers_appUserId",
                table: "cex",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cex_AspNetUsers_appUserId",
                table: "cex");

            migrationBuilder.RenameColumn(
                name: "appUserId",
                table: "cex",
                newName: "UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_cex_appUserId",
                table: "cex",
                newName: "IX_cex_UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_cex_AspNetUsers_UserIdId",
                table: "cex",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
