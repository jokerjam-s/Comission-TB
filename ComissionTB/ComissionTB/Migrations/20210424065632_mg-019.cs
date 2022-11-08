using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionTB.Migrations
{
    public partial class mg019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "osnova",
                table: "tAkt");

            migrationBuilder.AddColumn<string>(
                name: "osnova",
                table: "tPredp",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "osnova",
                table: "tPredp");

            migrationBuilder.AddColumn<string>(
                name: "osnova",
                table: "tAkt",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
