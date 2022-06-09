using Microsoft.EntityFrameworkCore.Migrations;

namespace Ruokalistat.tk.Migrations
{
    public partial class piilotettu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "piilotettu",
                table: "Ruokalista",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "piilotettu",
                table: "Ruokalista");
        }
    }
}
