using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class SimboloRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Simbolo",
                table: "TipoCuenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Simbolo",
                table: "TipoCuenta",
                nullable: false,
                defaultValue: "");
        }
    }
}
