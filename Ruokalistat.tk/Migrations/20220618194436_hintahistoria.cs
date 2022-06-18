using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ruokalistat.tk.Migrations
{
    public partial class hintahistoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hintahistoria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RuokaID = table.Column<int>(type: "INTEGER", nullable: true),
                    PVM = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hintahistoria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hintahistoria_Ruoka_RuokaID",
                        column: x => x.RuokaID,
                        principalTable: "Ruoka",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hintahistoria_RuokaID",
                table: "Hintahistoria",
                column: "RuokaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hintahistoria");
        }
    }
}
