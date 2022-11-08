using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionTB.Migrations
{
    public partial class mg007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isRuk",
                table: "tDolgn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isRuk",
                table: "tDolgn",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
