using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionTB.Migrations
{
    public partial class mg012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pomid_pom",
                table: "tPredp",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tPredp_pomid_pom",
                table: "tPredp",
                column: "pomid_pom");

            migrationBuilder.AddForeignKey(
                name: "FK_tPredp_tPom_pomid_pom",
                table: "tPredp",
                column: "pomid_pom",
                principalTable: "tPom",
                principalColumn: "id_pom",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tPredp_tPom_pomid_pom",
                table: "tPredp");

            migrationBuilder.DropIndex(
                name: "IX_tPredp_pomid_pom",
                table: "tPredp");

            migrationBuilder.DropColumn(
                name: "pomid_pom",
                table: "tPredp");
        }
    }
}
