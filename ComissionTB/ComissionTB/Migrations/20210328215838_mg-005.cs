using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionTB.Migrations
{
    public partial class mg005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPreds",
                table: "tSostav");

            migrationBuilder.DropColumn(
                name: "isSekr",
                table: "tSostav");

            migrationBuilder.AddColumn<bool>(
                name: "isRuk",
                table: "tDolgn",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PredsIdId",
                table: "tAkt",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SekrIdId",
                table: "tAkt",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserIdId",
                table: "cex",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tAkt_PredsIdId",
                table: "tAkt",
                column: "PredsIdId");

            migrationBuilder.CreateIndex(
                name: "IX_tAkt_SekrIdId",
                table: "tAkt",
                column: "SekrIdId");

            migrationBuilder.CreateIndex(
                name: "IX_cex_UserIdId",
                table: "cex",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_cex_AspNetUsers_UserIdId",
                table: "cex",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tAkt_AspNetUsers_PredsIdId",
                table: "tAkt",
                column: "PredsIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tAkt_AspNetUsers_SekrIdId",
                table: "tAkt",
                column: "SekrIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cex_AspNetUsers_UserIdId",
                table: "cex");

            migrationBuilder.DropForeignKey(
                name: "FK_tAkt_AspNetUsers_PredsIdId",
                table: "tAkt");

            migrationBuilder.DropForeignKey(
                name: "FK_tAkt_AspNetUsers_SekrIdId",
                table: "tAkt");

            migrationBuilder.DropIndex(
                name: "IX_tAkt_PredsIdId",
                table: "tAkt");

            migrationBuilder.DropIndex(
                name: "IX_tAkt_SekrIdId",
                table: "tAkt");

            migrationBuilder.DropIndex(
                name: "IX_cex_UserIdId",
                table: "cex");

            migrationBuilder.DropColumn(
                name: "isRuk",
                table: "tDolgn");

            migrationBuilder.DropColumn(
                name: "PredsIdId",
                table: "tAkt");

            migrationBuilder.DropColumn(
                name: "SekrIdId",
                table: "tAkt");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "cex");

            migrationBuilder.AddColumn<bool>(
                name: "isPreds",
                table: "tSostav",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isSekr",
                table: "tSostav",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
