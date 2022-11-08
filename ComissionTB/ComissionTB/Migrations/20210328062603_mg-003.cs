using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionTB.Migrations
{
    public partial class mg003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tObject");

            migrationBuilder.DropTable(
                name: "tPom");

            migrationBuilder.DropTable(
                name: "pomKind");

            migrationBuilder.DropColumn(
                name: "prOcen",
                table: "tPredp");

            migrationBuilder.AddColumn<string>(
                name: "ocenka",
                table: "tAkt",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ocenka",
                table: "tAkt");

            migrationBuilder.AddColumn<int>(
                name: "prOcen",
                table: "tPredp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "pomKind",
                columns: table => new
                {
                    id_pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pkName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    pkTreb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pomKind", x => x.id_pk);
                });

            migrationBuilder.CreateTable(
                name: "tPom",
                columns: table => new
                {
                    id_pom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cexid_cex = table.Column<int>(type: "int", nullable: true),
                    pomArea = table.Column<decimal>(type: "decimal(2)", maxLength: 10, precision: 2, nullable: true),
                    pomKindid_pk = table.Column<int>(type: "int", nullable: true),
                    pomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    table.ForeignKey(
                        name: "FK_tPom_pomKind_pomKindid_pk",
                        column: x => x.pomKindid_pk,
                        principalTable: "pomKind",
                        principalColumn: "id_pk",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tObject",
                columns: table => new
                {
                    id_obj = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    objInvNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    objName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    objNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pomid_pom = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tObject", x => x.id_obj);
                    table.ForeignKey(
                        name: "FK_tObject_tPom_pomid_pom",
                        column: x => x.pomid_pom,
                        principalTable: "tPom",
                        principalColumn: "id_pom",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pomKind_pkName",
                table: "pomKind",
                column: "pkName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tObject_pomid_pom",
                table: "tObject",
                column: "pomid_pom");

            migrationBuilder.CreateIndex(
                name: "IX_tPom_cexid_cex",
                table: "tPom",
                column: "cexid_cex");

            migrationBuilder.CreateIndex(
                name: "IX_tPom_pomKindid_pk",
                table: "tPom",
                column: "pomKindid_pk");
        }
    }
}
