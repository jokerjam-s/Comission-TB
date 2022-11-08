using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionTB.Migrations
{
    public partial class mg000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descript = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cex",
                columns: table => new
                {
                    id_cex = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cexNaame = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cex", x => x.id_cex);
                });

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
                name: "tDolgn",
                columns: table => new
                {
                    id_dl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dlName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tDolgn", x => x.id_dl);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tAkt",
                columns: table => new
                {
                    aktNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cexid_cex = table.Column<int>(type: "int", nullable: true),
                    aktDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tAkt", x => x.aktNo);
                    table.ForeignKey(
                        name: "FK_tAkt_cex_cexid_cex",
                        column: x => x.cexid_cex,
                        principalTable: "cex",
                        principalColumn: "id_cex",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tPom",
                columns: table => new
                {
                    id_pom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    pomArea = table.Column<decimal>(type: "decimal(2)", maxLength: 10, precision: 2, nullable: true),
                    cexid_cex = table.Column<int>(type: "int", nullable: true),
                    pomKindid_pk = table.Column<int>(type: "int", nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tabNo = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    userFio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userSecName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    userPriem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userDismis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    dolgnid_dl = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tDolgn_dolgnid_dl",
                        column: x => x.dolgnid_dl,
                        principalTable: "tDolgn",
                        principalColumn: "id_dl",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tObject",
                columns: table => new
                {
                    id_obj = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    objName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    objInvNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
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

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tPredp",
                columns: table => new
                {
                    prNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    prIspNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prIspDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    prOcen = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    aktNo = table.Column<int>(type: "int", nullable: true),
                    appUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPredp", x => x.prNo);
                    table.ForeignKey(
                        name: "FK_tPredp_AspNetUsers_appUserId",
                        column: x => x.appUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tPredp_tAkt_aktNo",
                        column: x => x.aktNo,
                        principalTable: "tAkt",
                        principalColumn: "aktNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tSostav",
                columns: table => new
                {
                    id_st = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isPreds = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    isSekr = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    aktNo = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tSostav", x => x.id_st);
                    table.ForeignKey(
                        name: "FK_tSostav_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tSostav_tAkt_aktNo",
                        column: x => x.aktNo,
                        principalTable: "tAkt",
                        principalColumn: "aktNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_dolgnid_dl",
                table: "AspNetUsers",
                column: "dolgnid_dl");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_cex_cexNaame",
                table: "cex",
                column: "cexName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pomKind_pkName",
                table: "pomKind",
                column: "pkName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tAkt_cexid_cex",
                table: "tAkt",
                column: "cexid_cex");

            migrationBuilder.CreateIndex(
                name: "IX_tDolgn_dlName",
                table: "tDolgn",
                column: "dlName",
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

            migrationBuilder.CreateIndex(
                name: "IX_tPredp_aktNo",
                table: "tPredp",
                column: "aktNo");

            migrationBuilder.CreateIndex(
                name: "IX_tPredp_appUserId",
                table: "tPredp",
                column: "appUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tSostav_aktNo",
                table: "tSostav",
                column: "aktNo");

            migrationBuilder.CreateIndex(
                name: "IX_tSostav_userId",
                table: "tSostav",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tObject");

            migrationBuilder.DropTable(
                name: "tPredp");

            migrationBuilder.DropTable(
                name: "tSostav");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tPom");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tAkt");

            migrationBuilder.DropTable(
                name: "pomKind");

            migrationBuilder.DropTable(
                name: "tDolgn");

            migrationBuilder.DropTable(
                name: "cex");
        }
    }
}
