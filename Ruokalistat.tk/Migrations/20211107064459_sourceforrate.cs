using Microsoft.EntityFrameworkCore.Migrations;

namespace Ruokalistat.tk.Migrations
{
    public partial class sourceforrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "source",
                table: "Arvostelu",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "source",
                table: "Arvostelu");
        }
    }
}
