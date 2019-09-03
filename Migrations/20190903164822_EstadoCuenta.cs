using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class EstadoCuenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta_CuentaAhorroId",
                table: "EstadoCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta_CuentaAhorroId",
                table: "EstadoCuenta",
                column: "CuentaAhorroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EstadoCuenta_CuentaAhorroId",
                table: "EstadoCuenta");

            migrationBuilder.CreateIndex(
                name: "IX_EstadoCuenta_CuentaAhorroId",
                table: "EstadoCuenta",
                column: "CuentaAhorroId",
                unique: true);
        }
    }
}
