using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionTB.Migrations
{
    public partial class mg020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "prim",
            //    table: "tPredp",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_cex",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "prim",
            //    table: "tPredp");

            migrationBuilder.DropColumn(
                name: "id_cex",
                table: "AspNetUsers");
        }
    }
}
