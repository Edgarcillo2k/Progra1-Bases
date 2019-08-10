using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_Bases.Migrations
{
    public partial class doc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "doc",
                table: "Persona",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "doc",
                table: "Persona");
        }
    }
}
