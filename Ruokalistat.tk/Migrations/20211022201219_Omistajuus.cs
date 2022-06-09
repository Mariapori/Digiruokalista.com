using Microsoft.EntityFrameworkCore.Migrations;

namespace Ruokalistat.tk.Migrations
{
    public partial class Omistajuus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Yritys",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yritys_OwnerId",
                table: "Yritys",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yritys_AspNetUsers_OwnerId",
                table: "Yritys",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Yritys_AspNetUsers_OwnerId",
                table: "Yritys");

            migrationBuilder.DropIndex(
                name: "IX_Yritys_OwnerId",
                table: "Yritys");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Yritys");
        }
    }
}
