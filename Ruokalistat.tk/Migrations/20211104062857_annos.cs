using Microsoft.EntityFrameworkCore.Migrations;

namespace Ruokalistat.tk.Migrations
{
    public partial class annos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Annos",
                table: "Ruoka",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Annos",
                table: "Ruoka");
        }
    }
}
