using Microsoft.EntityFrameworkCore.Migrations;

namespace Ruokalistat.tk.Migrations
{
    public partial class arvostelut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arvostelu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    yritysID = table.Column<int>(type: "INTEGER", nullable: true),
                    arvosana = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arvostelu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Arvostelu_Yritys_yritysID",
                        column: x => x.yritysID,
                        principalTable: "Yritys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arvostelu_yritysID",
                table: "Arvostelu",
                column: "yritysID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arvostelu");
        }
    }
}
