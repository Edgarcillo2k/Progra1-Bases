using Microsoft.EntityFrameworkCore.Migrations;

namespace Progra1_bases.Migrations
{
    public partial class Beneficiarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persona_CuentaAhorroId",
                table: "Persona");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_CuentaAhorroId",
                table: "Persona",
                column: "CuentaAhorroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persona_CuentaAhorroId",
                table: "Persona");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_CuentaAhorroId",
                table: "Persona",
                column: "CuentaAhorroId",
                unique: true,
                filter: "[CuentaAhorroId] IS NOT NULL");
        }
    }
}
