using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionTB.Migrations
{
    public partial class mg004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mailSetting",
                columns: table => new
                {
                    PostMail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PostSmtp = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PostPort = table.Column<int>(type: "int", nullable: false),
                    PostPass = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mailSetting");
        }
    }
}
