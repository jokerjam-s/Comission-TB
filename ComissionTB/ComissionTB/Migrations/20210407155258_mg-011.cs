using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionTB.Migrations
{
    public partial class mg011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tPom",
                columns: table => new
                {
                    id_pom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cexid_cex = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPom", x => x.id_pom);
                    table.ForeignKey(
                        name: "FK_tPom_cex_cexid_cex",
                        column: x => x.cexid_cex,
                        principalTable: "cex",
                        principalColumn: "id_cex",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tPom_cexid_cex",
                table: "tPom",
                column: "cexid_cex");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tPom");
        }
    }
}
