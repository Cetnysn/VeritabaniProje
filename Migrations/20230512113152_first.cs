using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VeritabanıProje.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sektors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sektors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fuars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sektor_adı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sektorId = table.Column<int>(type: "int", nullable: false),
                    aktif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fuars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fuars_sektors_sektorId",
                        column: x => x.sektorId,
                        principalTable: "sektors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sirkets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sektor_Id = table.Column<int>(type: "int", nullable: false),
                    sektor_adı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yetkili = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yetkiliTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    yetkiliMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fuar_Id = table.Column<int>(type: "int", nullable: false),
                    fuar_isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    onay = table.Column<bool>(type: "bit", nullable: false),
                    salon_no = table.Column<int>(type: "int", nullable: false),
                    stand_no = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sirkets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sirkets_fuars_fuar_Id",
                        column: x => x.fuar_Id,
                        principalTable: "fuars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_sirkets_sektors_sektor_Id",
                        column: x => x.sektor_Id,
                        principalTable: "sektors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ziyaretcis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fuarId = table.Column<int>(type: "int", nullable: false),
                    fuar_adı = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ziyaretcis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ziyaretcis_fuars_fuarId",
                        column: x => x.fuarId,
                        principalTable: "fuars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salon_no = table.Column<int>(type: "int", nullable: false),
                    stand_no = table.Column<int>(type: "int", nullable: false),
                    sirket_Id = table.Column<int>(type: "int", nullable: false),
                    sirket_isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fuar_Id = table.Column<int>(type: "int", nullable: false),
                    fuar_isim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stands_fuars_fuar_Id",
                        column: x => x.fuar_Id,
                        principalTable: "fuars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stands_sirkets_sirket_Id",
                        column: x => x.sirket_Id,
                        principalTable: "sirkets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fuars_sektorId",
                table: "fuars",
                column: "sektorId");

            migrationBuilder.CreateIndex(
                name: "IX_sirkets_fuar_Id",
                table: "sirkets",
                column: "fuar_Id");

            migrationBuilder.CreateIndex(
                name: "IX_sirkets_sektor_Id",
                table: "sirkets",
                column: "sektor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_stands_fuar_Id",
                table: "stands",
                column: "fuar_Id");

            migrationBuilder.CreateIndex(
                name: "IX_stands_sirket_Id",
                table: "stands",
                column: "sirket_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ziyaretcis_fuarId",
                table: "ziyaretcis",
                column: "fuarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "stands");

            migrationBuilder.DropTable(
                name: "ziyaretcis");

            migrationBuilder.DropTable(
                name: "sirkets");

            migrationBuilder.DropTable(
                name: "fuars");

            migrationBuilder.DropTable(
                name: "sektors");
        }
    }
}
