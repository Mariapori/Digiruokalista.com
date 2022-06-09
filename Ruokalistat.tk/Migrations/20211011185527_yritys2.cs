using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ruokalistat.tk.Migrations
{
    public partial class yritys2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ruokalista",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    viimeksiPaivitetty = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruokalista", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nimi = table.Column<string>(type: "TEXT", nullable: true),
                    Kuvaus = table.Column<string>(type: "TEXT", nullable: true),
                    RuokalistaID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kategoria_Ruokalista_RuokalistaID",
                        column: x => x.RuokalistaID,
                        principalTable: "Ruokalista",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yritys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nimi = table.Column<string>(type: "TEXT", nullable: true),
                    yTunnus = table.Column<string>(type: "TEXT", nullable: true),
                    Osoite = table.Column<string>(type: "TEXT", nullable: true),
                    Postinumero = table.Column<string>(type: "TEXT", nullable: true),
                    Kaupunki = table.Column<string>(type: "TEXT", nullable: true),
                    Puhelin = table.Column<string>(type: "TEXT", nullable: true),
                    RuokalistaID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yritys", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Yritys_Ruokalista_RuokalistaID",
                        column: x => x.RuokalistaID,
                        principalTable: "Ruokalista",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ruoka",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nimi = table.Column<string>(type: "TEXT", nullable: true),
                    Kuvaus = table.Column<string>(type: "TEXT", nullable: true),
                    Vegan = table.Column<bool>(type: "INTEGER", nullable: false),
                    Hinta = table.Column<decimal>(type: "TEXT", nullable: false),
                    KategoriaID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruoka", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ruoka_Kategoria_KategoriaID",
                        column: x => x.KategoriaID,
                        principalTable: "Kategoria",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kategoria_RuokalistaID",
                table: "Kategoria",
                column: "RuokalistaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ruoka_KategoriaID",
                table: "Ruoka",
                column: "KategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Yritys_RuokalistaID",
                table: "Yritys",
                column: "RuokalistaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ruoka");

            migrationBuilder.DropTable(
                name: "Yritys");

            migrationBuilder.DropTable(
                name: "Kategoria");

            migrationBuilder.DropTable(
                name: "Ruokalista");
        }
    }
}
