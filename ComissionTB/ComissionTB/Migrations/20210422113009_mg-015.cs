using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionTB.Migrations
{
    public partial class mg015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SoglPreds",
                table: "tAkt",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SoglSecr",
                table: "tAkt",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoglPreds",
                table: "tAkt");

            migrationBuilder.DropColumn(
                name: "SoglSecr",
                table: "tAkt");
        }
    }
}
