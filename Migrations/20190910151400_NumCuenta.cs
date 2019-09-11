using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class NumCuenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumCuenta",
                table: "CuentaAhorro",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumCuenta",
                table: "CuentaAhorro");
        }
    }
}
